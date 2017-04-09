using Feedback.Core.Helpers;
using Feedback.Core.Models;
using Feedback.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Data.Repositories
{
    public class SurveyChoicesRepository :Repository<SurveyChoiceModel>,ISurveyChoicesRepository
    {
        public SurveyChoicesRepository(IDatabaseHelper databaseHelper) : base(databaseHelper)
        {
        }
    }
}
