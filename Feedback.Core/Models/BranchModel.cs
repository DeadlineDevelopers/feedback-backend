using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Models
{
    [Table("BRANCH")]
    public class BranchModel : BaseModel
    {
        public string Code { get; set; }

        public string BranchName { get; set; }

        public int ActivePassiveId { get; set; }

        public long EntityId { get; set; }
    }
}
