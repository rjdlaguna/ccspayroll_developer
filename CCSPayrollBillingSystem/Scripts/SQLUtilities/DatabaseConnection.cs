using System;
using System.Data;
using System.Data.SqlClient;

namespace CCSPayrollBillingSystem.Scripts
{
    class DatabaseConnection:IDisposable
    {
        private readonly SqlConnection _connection;

        public DatabaseConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
