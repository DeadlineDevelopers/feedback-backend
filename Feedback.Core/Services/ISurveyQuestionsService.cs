using Feedback.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Services
{
    public interface ISurveyQuestionsService : IService<SurveyQuestionModel>
    {
        IList<SurveyQuestionModel> All(long surveyId);
    }
}
