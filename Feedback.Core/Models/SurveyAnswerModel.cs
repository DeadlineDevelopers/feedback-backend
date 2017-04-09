using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Models
{
    [Table("SURVEYANSWER")]
    public class SurveyAnswerModel : BaseModel
    {
        public long QuestionId { get; set; }

        public long ChoiceId { get; set; }

        public long FreeTextArea { get; set; }
    }
}
