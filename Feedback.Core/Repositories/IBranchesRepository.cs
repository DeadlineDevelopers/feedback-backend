using Feedback.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Repositories
{
    public interface IBranchesRepository : IRepository<BranchModel>
    {
        IList<BranchModel> All(long entityId);
    }
}
