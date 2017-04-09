using Feedback.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Services
{
    public interface IEntitiesService : IService<EntityModel>
    {
        IList<EntityModel> All(long companyId);
    }
}
