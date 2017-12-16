using System.Collections.Generic;
using Business.Services.Interfaces;
using CreatingModels;
using Data.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SkillpointAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Tags")]
    public class TagsController : Controller
    {

        private readonly ITagsService _service;

        public TagsController(ITagsService service)
        {
            this._service = service;
        }

        // GET: api/Tags
        [HttpGet]
        public IEnumerable<Tag> GetTags()
        {
            return _service.GetAllTags();
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public Tag GetTag([FromRoute] string label)
        {
            return _service.GetTagByLabel(label);
        }

    
        // POST: api/Tags
        [HttpPost]
        public void PostTag([FromBody] TagCreatingModel tagModel)
        {
            var tagLabel = tagModel.Label;
            if (_service.GetByLabel(tagLabel) == null)
            {
                //momentan cream un user, doarece nu avem service-ul de user
                var tag = Tag.Create(tagModel);
                _service.CreateTag(tag);
            }
            else
            {
                //momentan cream un user, doarece nu avem service-ul de user
                var tag = _service.GetTagByLabel(tagLabel);
                tag.Update(tagLabel,false);
                _service.UpdateTag(tag);
            }
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public void DeleteTag([FromRoute] string label)
        {
            _service.DeleteTag(label);
        }
    }
}