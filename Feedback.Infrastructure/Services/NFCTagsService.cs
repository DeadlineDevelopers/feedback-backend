using Feedback.Core.Repositories;
using Feedback.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.Core.Models;

namespace Feedback.Infrastructure.Services
{
    public class NFCTagsService : INFCTagsService
    {
        private INFCTagsRepository _repository;

        public NFCTagsService(INFCTagsRepository repository)
        {
            _repository = repository;
        }

        public IList<NFCTagModel> All()
        {
            return _repository.All();
        }

        public NFCTagModel Create(NFCTagModel model)
        {
            return _repository.Create(model);
        }

        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }

        public NFCTagModel Find(long id)
        {
            return _repository.Find(id);
        }

        public bool Update(NFCTagModel model)
        {
            return _repository.Update(model);
        }
    }
}
