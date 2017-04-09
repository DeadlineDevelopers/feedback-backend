using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Models
{
    public interface IModel
    {
        long Id { get; set; }
        //DateTime? CreatedAt { get; set; }
        //DateTime? UpdatedAt { get; set; }
        //int CreatedBy { get; set; }
        //int UpdatedBy { get; set; }
    }
}
