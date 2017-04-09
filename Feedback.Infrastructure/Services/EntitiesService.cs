using Feedback.Core.Repositories;
using Feedback.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.Core.Models;

namespace Feedback.Infrastructure.Services
{
    public class EntitiesService : IEntitiesService
    {
        private IEntitiesRepository _repository;

        public EntitiesService(IEntitiesRepository repository)
        {
            _repository = repository;
        }

        public IList<EntityModel> All()
        {
            return _repository.All();
        }

        public IList<EntityModel> All(long companyId)
        {
            return _repository.All(companyId);
        }

        public EntityModel Create(EntityModel model)
        {
            return _repository.Create(model);
        }

        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }

        public EntityModel Find(long id)
        {
            return _repository.Find(id);
        }

        public bool Update(EntityModel model)
        {
            return _repository.Update(model);
        }
    }
}
