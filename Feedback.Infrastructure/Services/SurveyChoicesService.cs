using Feedback.Core.Repositories;
using Feedback.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.Core.Models;

namespace Feedback.Infrastructure.Services
{
    public class SurveyChoicesService : ISurveyChoicesService
    {
        private ISurveyChoicesRepository _repository;

        public SurveyChoicesService(ISurveyChoicesRepository repository)
        {
            _repository = repository;
        }

        public IList<SurveyChoiceModel> All()
        {
            return _repository.All();
        }

        public SurveyChoiceModel Create(SurveyChoiceModel model)
        {
            return _repository.Create(model);
        }

        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }

        public SurveyChoiceModel Find(long id)
        {
            return _repository.Find(id);
        }

        public bool Update(SurveyChoiceModel model)
        {
            return _repository.Update(model);
        }
    }
}
