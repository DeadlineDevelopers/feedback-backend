using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Models
{
    public class BaseModel : IModel
    {
        [Key]
        public long Id { get; set; }

        //public DateTime? CreatedAt { get; set; }

        //public DateTime? UpdatedAt { get; set; }

        //public int UpdatedBy { get; set; }

        //public int CreatedBy { get; set; }
    }
}
