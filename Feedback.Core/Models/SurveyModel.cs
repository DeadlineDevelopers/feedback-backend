using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Models
{
    [Table("SURVEY")]
    public class SurveyModel : BaseModel
    {
        public long EntityId { get; set; }

        [Computed]
        public string EntityName { get; set; }

        public long BranchId { get; set; }

        [Computed]
        public string BranchName { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int ActivePassiveId { get; set; }
    }
}
