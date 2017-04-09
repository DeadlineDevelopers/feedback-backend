using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Feedback.Core.Models;
using Feedback.Core.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Feedback.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private ICompaniesService _companiesService;
        private IEntitiesService _entitiesService;

        public CompaniesController(ICompaniesService companiesService, IEntitiesService entitiesService )
        {
            _companiesService = companiesService;
            _entitiesService = entitiesService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<CompanyModel> Get([FromQuery] int? activePassiveId)
        {
            if (activePassiveId != null)
                return _companiesService.All().Where(c => c.ActivePassiveId == activePassiveId);
            return _companiesService.All();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get(long id)
        {
            var company = _companiesService.Find(id);
            if (company == null)
            {
                return NotFound();
            }
            return new ObjectResult(company);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CompanyModel companyModel)
        {
            if (companyModel == null)
            {
                return BadRequest();
            }
            TryValidateModel(companyModel);
            if (this.ModelState.IsValid)
            {
                var company = _companiesService.Create(companyModel);
                return CreatedAtRoute("GetCustomer", new { controller = "Companies", id = company.Id }, company);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]CompanyModel companyModel)
        {
            if (companyModel == null || companyModel.Id != id)
            {
                return BadRequest();
            }

            var company = _companiesService.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            TryValidateModel(companyModel);
            if (this.ModelState.IsValid)
            {
                company.Name = companyModel.Name;
                company.ActivePassiveId = companyModel.ActivePassiveId;

                _companiesService.Update(company);
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
            var company = _companiesService.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            _companiesService.Delete(id);
            return new NoContentResult();
        }

        //Handling Relations
        // GET: api/values/5/entities
        //[HttpGet]
        //[Route("{companyId}/entities")]
        //public IEnumerable<EntityModel> All(long companyId)
        //{
        //    return _entitiesService.All(companyId);
        //}
    }
}
