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
    public class SurveyQuestionsController : Controller
    {
        private ISurveyQuestionsService _surveyQuestionsService;

        public SurveyQuestionsController(ISurveyQuestionsService surveyQuestionsService)
        {
            _surveyQuestionsService = surveyQuestionsService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<SurveyQuestionModel> Get(long? surveyId)
        {
            if (surveyId != null)
                return _surveyQuestionsService.All(Convert.ToInt64(surveyId));
            return _surveyQuestionsService.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
