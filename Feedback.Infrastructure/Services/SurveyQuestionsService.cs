using Feedback.Core.Repositories;
using Feedback.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.Core.Models;

namespace Feedback.Infrastructure.Services
{
    public class SurveyQuestionsService : ISurveyQuestionsService
    {
        private ISurveyQuestionsRepository _repository;

        public SurveyQuestionsService(ISurveyQuestionsRepository repository)
        {
            _repository = repository;
        }

        public IList<SurveyQuestionModel> All()
        {
            return _repository.All();
        }

        public IList<SurveyQuestionModel> All(long surveyId)
        {
            return _repository.All(surveyId);
        }

        public SurveyQuestionModel Create(SurveyQuestionModel model)
        {
            return _repository.Create(model);
        }

        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }

        public SurveyQuestionModel Find(long id)
        {
            return _repository.Find(id);
        }

        public bool Update(SurveyQuestionModel model)
        {
            return _repository.Update(model);
        }
    }
}
