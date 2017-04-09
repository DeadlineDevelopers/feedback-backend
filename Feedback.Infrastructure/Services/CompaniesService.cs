using Feedback.Core.Repositories;
using Feedback.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.Core.Models;

namespace Feedback.Infrastructure.Services
{
    public class CompaniesService : ICompaniesService
    {
        private ICompaniesRepository _repository;

        public CompaniesService(ICompaniesRepository repository)
        {
            _repository = repository;
        }

        public IList<CompanyModel> All()
        {
            return _repository.All();
        }

        public CompanyModel Create(CompanyModel model)
        {
            return _repository.Create(model);
        }

        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }

        public CompanyModel Find(long id)
        {
            return _repository.Find(id);
        }

        public bool Update(CompanyModel model)
        {
            return _repository.Update(model);
        }
    }
}
