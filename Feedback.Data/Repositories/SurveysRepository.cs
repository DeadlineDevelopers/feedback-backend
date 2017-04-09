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
    public class SurveysRepository : Repository<SurveyModel>,ISurveysRepository
    {
        public SurveysRepository(IDatabaseHelper databaseHelper) : base(databaseHelper)
        {

        }

        public IList<SurveyModel> All(long entityId)
        {
            using (var sqlConnection = _dbHelper.OpenConnection())
            {
                string query = String.Format("Select * from SURVEY where ENTITYID = {0}", entityId);

                var surveys = sqlConnection.Query<SurveyModel>(query).ToList();

                return surveys;
            }
        }

        public IList<SurveyModel> All(long entityId, long branchId)
        {
            using (var sqlConnection = _dbHelper.OpenConnection())
            {
                string query = String.Format("Select * from SURVEY where ENTITYID = {0} and BRANCHID = {1}", entityId,branchId);

                var surveys = sqlConnection.Query<SurveyModel>(query).ToList();

                return surveys;
            }
        }
    }
}
