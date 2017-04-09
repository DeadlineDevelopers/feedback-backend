using Feedback.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.Core.Models;
using Feedback.Core.Repositories;

namespace Feedback.Infrastructure.Services
{
    public class BranchesService : IBranchesService
    {
        private IBranchesRepository _repository;

        public BranchesService(IBranchesRepository repository)
        {
            _repository = repository;
        }

        public IList<BranchModel> All()
        {
            return _repository.All();
        }

        public IList<BranchModel> All(long entityId)
        {
            return _repository.All(entityId);
        }

        public BranchModel Create(BranchModel model)
        {
            return _repository.Create(model);
        }

        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }

        public BranchModel Find(long id)
        {
            return _repository.Find(id);
        }

        public bool Update(BranchModel model)
        {
            return _repository.Update(model);
        }
    }
}
