using Business.Interfaces;
using Business.Repositories.Implementations;
<<<<<<< HEAD
=======
using Business.Repositories.Interfaces;
>>>>>>> 30b46ff91fca14165d8d5d5630d68b68a50e0334
using Business.Services.Implementations;
using Business.Services.Interfaces;
using Data.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace SkillpointAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDatabaseContext, DatabaseContext>();
            services.AddTransient<ITagsRepository, TagsRepository>();
            services.AddTransient<IEventsRepository, EventsRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IEventService, EventService>();

            var connectionString = @"Server = .\SQLEXPRESS; Database = Skillpoint.Dev; Trusted_Connection = true";

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Skillpoint API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {   
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skillpoint V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
