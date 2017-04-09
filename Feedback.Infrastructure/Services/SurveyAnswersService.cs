using Feedback.Core.Repositories;
using Feedback.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.Core.Models;

namespace Feedback.Infrastructure.Services
{
    public class SurveyAnswersService : ISurveyAnswersService
    {
        private ISurveyAnswersRepository _repository;

        public SurveyAnswersService(ISurveyAnswersRepository repository)
        {
            _repository = repository;
        }

        public IList<SurveyAnswerModel> All()
        {
            return _repository.All();
        }

        public SurveyAnswerModel Create(SurveyAnswerModel model)
        {
            return _repository.Create(model);
        }

        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }

        public SurveyAnswerModel Find(long id)
        {
            return _repository.Find(id);
        }

        public bool Update(SurveyAnswerModel model)
        {
            return _repository.Update(model);
        }
    }
}
