using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Models
{
    [Table("NFCTAG")]
    public class NFCTagModel : BaseModel
    {
        public string Description { get; set; }

        public long SurveyId { get; set; }
    }
}
