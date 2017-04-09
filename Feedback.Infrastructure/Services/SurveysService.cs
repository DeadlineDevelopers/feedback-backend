using Feedback.Core.Repositories;
using Feedback.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.Core.Models;

namespace Feedback.Infrastructure.Services
{
    public class SurveysService : ISurveysService
    {
        private ISurveysRepository _repository;

        public SurveysService(ISurveysRepository repository)
        {
            _repository = repository;
        }

        public IList<SurveyModel> All()
        {
            return _repository.All();
        }

        public IList<SurveyModel> All(long entityId)
        {
            return _repository.All(entityId);
        }

        public IList<SurveyModel> All(long entityId, long branchId)
        {
            return _repository.All(entityId, branchId);
        }

        public SurveyModel Create(SurveyModel model)
        {
            return _repository.Create(model);
        }

        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }

        public SurveyModel Find(long id)
        {
            return _repository.Find(id);
        }

        public bool Update(SurveyModel model)
        {
            return _repository.Update(model);
        }
    }
}
