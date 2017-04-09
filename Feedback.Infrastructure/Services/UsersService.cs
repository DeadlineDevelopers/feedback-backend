using Feedback.Core.Repositories;
using Feedback.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.Core.Models;

namespace Feedback.Infrastructure.Services
{
    public class UsersService : IUsersService
    {
        private IUsersRepository _repository;

        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public IList<UserModel> All()
        {
            return _repository.All();
        }

        public UserModel Create(UserModel model)
        {
            return _repository.Create(model);
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public UserModel Find(long id)
        {
            return _repository.Find(id);
        }

        public bool Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
