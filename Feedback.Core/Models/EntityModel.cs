using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Models
{
    [Table("ENTITY")]
    public class EntityModel : BaseModel
    {
        [Required]
        public string Code { get; set; }

        public string EntityName { get; set; }

        public long CompanyId { get; set; }

        [Computed]
        public string CompanyName { get; set; }

        public int ActivePassiveId { get; set; }
    }
}
