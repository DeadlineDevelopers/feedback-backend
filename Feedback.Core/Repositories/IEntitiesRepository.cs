﻿using Feedback.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Repositories
{
    public interface IEntitiesRepository : IRepository<EntityModel>
    {
        IList<EntityModel> All(long companyId);
    }
}
