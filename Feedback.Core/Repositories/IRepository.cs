using Feedback.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Repositories
{
    public interface IRepository<T>
        where T : IModel
    {
        IList<T> All();
        T Find(long id);
        T Create(T model);
        bool Update(T model);
        bool Delete(long id);
    }
}
