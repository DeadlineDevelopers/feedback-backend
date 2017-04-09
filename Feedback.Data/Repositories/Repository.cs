using Feedback.Core.Helpers;
using Feedback.Core.Models;
using Feedback.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Feedback.Data.Repositories
{
    public class Repository<M> : IRepository<M>
        where M : BaseModel
    {
        protected IDatabaseHelper _dbHelper;

        public Repository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public IList<M> All()
        {
            using (var sqlConnection = _dbHelper.OpenConnection())
            {
                var result = sqlConnection.GetAll<M>().ToList();
                return result;
            }
        }

        public virtual M Create(M model)
        {
            using (var sqlConnection = _dbHelper.OpenConnection())
            {
                //model.CreatedAt = model.UpdatedAt = DateTime.Now;
                var id = sqlConnection.Insert(model);
                var result = Find((int)id);
                return result;
            }
        }

        public bool Delete(long id)
        {
            using (var sqlConnection = _dbHelper.OpenConnection())
            {
                var item = sqlConnection.Get<M>(id);
                var result = sqlConnection.Delete(item);
                return result;
            }
        }

        public M Find(long id)
        {
            using (var sqlConnection = _dbHelper.OpenConnection())
            {
                var result = sqlConnection.Get<M>(id);
                return result;
            }
        }

        public virtual bool Update(M model)
        {
            using (var sqlConnection = _dbHelper.OpenConnection())
            {
                //model.UpdatedAt = DateTime.Now;
                var result = sqlConnection.Update(model);
                return result;
            }
        }
    }
}
