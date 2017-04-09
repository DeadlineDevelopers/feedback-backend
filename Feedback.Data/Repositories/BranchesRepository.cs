using Dapper;
using Feedback.Core.Helpers;
using Feedback.Core.Models;
using Feedback.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Data.Repositories
{
    public class BranchesRepository : Repository<BranchModel>,IBranchesRepository
    {
        public BranchesRepository(IDatabaseHelper databaseHelper) : base(databaseHelper)
        {
        }

        public IList<BranchModel> All(long entityId)
        {
            using (var sqlConnection = _dbHelper.OpenConnection())
            {
                string query = String.Format("Select * from BRANCH where ENTITYID = {0}", entityId);

                var branches = sqlConnection.Query<BranchModel>(query).ToList();

                return branches;
            }
        }
    }
}
