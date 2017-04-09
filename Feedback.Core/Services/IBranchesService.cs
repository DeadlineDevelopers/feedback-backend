using Feedback.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Services
{
    public interface IBranchesService : IService<BranchModel>
    {
        IList<BranchModel> All(long entityId);
    }
}
