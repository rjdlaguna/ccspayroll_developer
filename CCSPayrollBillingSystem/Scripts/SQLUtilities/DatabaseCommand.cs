using System;
using System.Data;
using System.Data.SqlClient;

namespace CCSPayrollBillingSystem.Scripts
{
    class DatabaseCommand:IDisposable
    {
        private readonly SqlCommand _command;

        public DatabaseCommand(string commandText, DatabaseConnection connection)
        {
            _command = new SqlCommand(commandText, connection.GetConnection());
            _command.Connection = connection.GetConnection();
        }

        public void AddParameter(string parameterName, object value)
        {
            _command.Parameters.AddWithValue(parameterName, value);
        }

        public SqlDataReader ExecuteReader()
        {
            return _command.ExecuteReader();
        }

        public void Dispose()
        {
            _command.Dispose();
        }
    }
}
