using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CreatingModels;
using Data.Domain.Entities;
using Data.Persistence;
using DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace SkillpointAPI.Controllers
{
    public partial class TokenController : Controller
    {
        private DatabaseContext context;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private IConfiguration configuration;

        public TokenController(
            DatabaseContext _context,
            RoleManager<IdentityRole> _roleManager,
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            IConfiguration _configuration)
        {
            context = _context;
            roleManager = _roleManager;
            userManager = _userManager;
            signInManager = _signInManager;
            configuration = _configuration;
        }

        protected SignInManager<User> SignInManager { get; private set; }

        [HttpPost("Auth")]
        public async Task<object> Auth([FromBody] TokenCreatingModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = userManager.Users.SingleOrDefault(r => r.UserName == model.Username);
                return await GenerateJwtToken(model.Username, appUser);
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }

        private async Task<object> GenerateJwtToken(string username, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Auth:Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["Auth:Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                configuration["Auth:Jwt:Issuer"],
                configuration["Auth:Jwt:Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

