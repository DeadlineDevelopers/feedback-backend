using Feedback.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Core.Repositories
{
    public interface ISurveyQuestionsRepository : IRepository<SurveyQuestionModel>
    {
        IList<SurveyQuestionModel> All(long surveyId);
    }
}
