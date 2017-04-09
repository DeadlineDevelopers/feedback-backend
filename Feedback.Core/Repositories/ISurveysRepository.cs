using Feedback.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Repositories
{
    public interface ISurveysRepository : IRepository<SurveyModel>
    {
        IList<SurveyModel> All(long entityId);

        IList<SurveyModel> All(long entityId,long branchId);
    }
}
