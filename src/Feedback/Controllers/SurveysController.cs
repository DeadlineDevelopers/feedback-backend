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
    public class SurveysController : Controller
    {
        private ISurveysService _surveysService;

        public SurveysController(ISurveysService surveysService)
        {
            _surveysService = surveysService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<SurveyModel> All([FromQuery]long? entityId, [FromQuery]long? branchId, [FromQuery] int? activePassiveId)
        {
            if (entityId != null)
            {
                if (branchId != null)
                {
                    if (activePassiveId != null)
                        return _surveysService.All(Convert.ToInt64(entityId), Convert.ToInt64(branchId)).Where(s => s.ActivePassiveId == activePassiveId);
                    return _surveysService.All(Convert.ToInt64(entityId), Convert.ToInt64(branchId));
                }
                else
                {
                    if (activePassiveId != null)
                        return _surveysService.All(Convert.ToInt64(entityId)).Where(s => s.ActivePassiveId == activePassiveId);
                    return _surveysService.All(Convert.ToInt64(entityId));
                }
            }
            else if (branchId != null)
            {
                //
            }
            else if (activePassiveId != null)
            {
                return _surveysService.All().Where(s => s.ActivePassiveId == Convert.ToInt32(activePassiveId));
            }
            return _surveysService.All();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetSurvey")]
        public IActionResult Get(long id)
        {
            var survey = _surveysService.Find(id);
            if (survey == null)
            {
                return NotFound();
            }
            return new ObjectResult(survey);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SurveyModel surveyModel)
        {
            if (surveyModel == null)
            {
                return BadRequest();
            }
            TryValidateModel(surveyModel);
            if (this.ModelState.IsValid)
            {
                var survey = _surveysService.Create(surveyModel);
                return CreatedAtRoute("GetSurvey", new { controller = "Surveys", id = survey.Id }, survey);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]SurveyModel surveyModel)
        {
            if (surveyModel == null || surveyModel.Id != id)
            {
                return BadRequest();
            }

            var survey = _surveysService.Find(id);
            if (survey == null)
            {
                return NotFound();
            }

            TryValidateModel(surveyModel);
            if (this.ModelState.IsValid)
            {
                survey.Description = surveyModel.Description;
                survey.StartDate = surveyModel.StartDate;
                survey.EndDate = surveyModel.EndDate;
                survey.EntityId = surveyModel.EntityId;
                survey.BranchId = surveyModel.BranchId;
                survey.ActivePassiveId = surveyModel.ActivePassiveId;

                _surveysService.Update(survey);
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
            var survey = _surveysService.Find(id);
            if (survey == null)
            {
                return NotFound();
            }

            _surveysService.Delete(id);
            return new NoContentResult();
        }
    }
}
