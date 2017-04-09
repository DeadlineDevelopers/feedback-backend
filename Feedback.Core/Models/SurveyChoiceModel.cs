using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Models
{
    [Table("SURVEYCHOICE")]
    public class SurveyChoiceModel : BaseModel
    {
        public long SurveyQuestionId { get; set; }

        public string Description { get; set; }
    }
}
