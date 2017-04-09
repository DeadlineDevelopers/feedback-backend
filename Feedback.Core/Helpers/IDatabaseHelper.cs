using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.Core.Helpers
{
    public interface IDatabaseHelper
    {
        void SetConnection(string name);
        void SetConnectionString(string connectionString);
        SqlConnection OpenConnection();
    }
}
