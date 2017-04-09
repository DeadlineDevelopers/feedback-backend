using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Models
{
    [Table("COMPANY")]
    public class CompanyModel : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int ActivePassiveId { get; set; }
    }
}
