using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Feedback.Core.Services;
using Feedback.Core.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Feedback.Controllers
{
    [Route("api/[controller]")]
    public class EntitiesController : Controller
    {
        private IEntitiesService _entitiesService;

        public EntitiesController(IEntitiesService entitiesService)
        {
            _entitiesService = entitiesService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<EntityModel> All([FromQuery]long? companyId, [FromQuery] int? activePassiveId)
        {
            if (companyId != null)
            {
                if (activePassiveId != null)
                    return _entitiesService.All(Convert.ToInt64(companyId)).Where(e => e.ActivePassiveId == activePassiveId);
                return _entitiesService.All(Convert.ToInt64(companyId));
            }
            else if (activePassiveId != null)
            {
                return _entitiesService.All().Where(c => c.ActivePassiveId == Convert.ToInt32(activePassiveId));
            }
            return _entitiesService.All();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetEntity")]
        public IActionResult Get(long id)
        {
            var entity = _entitiesService.Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            return new ObjectResult(entity);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]EntityModel entityModel)
        {
            if (entityModel == null)
            {
                return BadRequest();
            }
            TryValidateModel(entityModel);
            if (this.ModelState.IsValid)
            {
                var entity = _entitiesService.Create(entityModel);
                return CreatedAtRoute("GetEntity", new { controller = "Entities", id = entity.Id }, entity);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]EntityModel entityModel)
        {
            if (entityModel == null || entityModel.Id != id)
            {
                return BadRequest();
            }

            var entity = _entitiesService.Find(id);
            if (entity == null)
            {
                return NotFound();
            }

            TryValidateModel(entityModel);
            if (this.ModelState.IsValid)
            {
                entity.Code = entityModel.Code;
                entity.EntityName = entityModel.EntityName;
                entity.CompanyId = entityModel.CompanyId;
                entity.ActivePassiveId = entityModel.ActivePassiveId;

                _entitiesService.Update(entity);
                return new NoContentResult();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var entity = _entitiesService.Find(id);
            if (entity == null)
            {
                return NotFound();
            }

            _entitiesService.Delete(id);
            return new NoContentResult();
        }
    }
}
