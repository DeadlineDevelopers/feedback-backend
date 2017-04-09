using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Models
{
    [Table("SURVEYQUESTION")]
    public class SurveyQuestionModel : BaseModel
    {
        public SurveyQuestionModel()
        {
            Choices = new List<SurveyChoiceModel>();
        }
        public long SurveyId { get; set; }

        public string Description { get; set; }

        public int QuestionTypeId { get; set; }

        public List<SurveyChoiceModel> Choices { get; set; }
    }
}
