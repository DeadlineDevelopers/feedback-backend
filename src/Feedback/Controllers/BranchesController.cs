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
    public class BranchesController : Controller
    {
        private IBranchesService _branchesService;

        public BranchesController(IBranchesService branchesService)
        {
            _branchesService = branchesService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<BranchModel> All([FromQuery]long? entityId, [FromQuery] int? activePassiveId)
        {
            if (entityId != null)
            {
                if (activePassiveId != null)
                    return _branchesService.All(Convert.ToInt64(entityId)).Where(e => e.ActivePassiveId == activePassiveId);
                return _branchesService.All(Convert.ToInt64(entityId));
            }
            else if (activePassiveId != null)
            {
                return _branchesService.All().Where(c => c.ActivePassiveId == Convert.ToInt32(activePassiveId));
            }
            return _branchesService.All();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetBranch")]
        public IActionResult Get(long id)
        {
            var branch = _branchesService.Find(id);
            if (branch == null)
            {
                return NotFound();
            }
            return new ObjectResult(branch);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]BranchModel branchModel)
        {
            if (branchModel == null)
            {
                return BadRequest();
            }
            TryValidateModel(branchModel);
            if (this.ModelState.IsValid)
            {
                var branch = _branchesService.Create(branchModel);
                return CreatedAtRoute("GetBranch", new { controller = "Branches", id = branch.Id }, branch);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]BranchModel branchModel)
        {
            if (branchModel == null || branchModel.Id != id)
            {
                return BadRequest();
            }

            var branch = _branchesService.Find(id);
            if (branch == null)
            {
                return NotFound();
            }

            TryValidateModel(branchModel);
            if (this.ModelState.IsValid)
            {
                branch.Code = branchModel.Code;
                branch.BranchName = branchModel.BranchName;
                branch.EntityId = branchModel.EntityId;
                branch.ActivePassiveId = branchModel.ActivePassiveId;

                _branchesService.Update(branch);
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
            var branch = _branchesService.Find(id);
            if (branch == null)
            {
                return NotFound();
            }

            _branchesService.Delete(id);
            return new NoContentResult();
        }
    }
}
