using System.Data.SqlClient;
using System.Reflection;
using System.Collections.Generic;
using Feedback.Core.Helpers;

namespace Feedback.Data.Helpers
{
    public class DapperHelper : IDatabaseHelper
    {
        private string _connectionName;
        private string _connectionString;
        //private SqlConnection _sqlConnection;

        public DapperHelper()
        {
            var defaultConnection = "Con";
            SetConnection(defaultConnection);
        }

        public void SetConnection(string name)
        {
            _connectionName = name;
            _connectionString = @"Server=.;Database=FEEDBACK;Trusted_Connection=true;";
        }

        public void SetConnectionString(string connectionString)
        {
            _connectionName = string.Empty;
            _connectionString = connectionString;
        }

        public SqlConnection OpenConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}