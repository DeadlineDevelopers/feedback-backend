using Dapper;
using Feedback.Core.Helpers;
using Feedback.Core.Models;
using Feedback.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Data.Repositories
{
    public class SurveyQuestionsRepository : Repository<SurveyQuestionModel>, ISurveyQuestionsRepository
    {
        public SurveyQuestionsRepository(IDatabaseHelper databaseHelper) : base(databaseHelper)
        {
        }

        public IList<SurveyQuestionModel> All(long surveyId)
        {
            using (var sqlConnection = _dbHelper.OpenConnection())
            {
                var lookup = new Dictionary<long, SurveyQuestionModel>();
                string query = String.Format(@"select *
                                               from SURVEYQUESTION as question
                                               inner join SURVEYCHOICE as choice on question.ID = choice.SURVEYQUESTIONID
                                               where SURVEYID = {0}", surveyId);

                var surveyQuestions = sqlConnection.Query<SurveyQuestionModel, SurveyChoiceModel, SurveyQuestionModel>
                    (query, (question, choice) =>
                    {
                        SurveyQuestionModel questionModel;
                        if (!lookup.TryGetValue(question.Id, out questionModel))
                            lookup.Add(question.Id, questionModel = question);

                        if (choice != null)
                            questionModel.Choices.Add(choice);

                        return questionModel;
                    }, splitOn: "ID").ToList();

                return lookup.Values.ToList();
            }
        }
    }
}
