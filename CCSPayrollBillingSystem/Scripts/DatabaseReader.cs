using System;
using System.Data;
using System.Data.SqlClient;

namespace CCSPayrollBillingSystem.Scripts
{
    class DatabaseReader:IDisposable
    {
        private readonly SqlDataReader _reader;

        public DatabaseReader(SqlDataReader reader)
        {
            _reader = reader;
        }

        public bool Read()
        {
            return _reader.Read();
        }

        public object GetValue(int index)
        {
            return _reader[index];
        }

        public void Dispose()
        {
            _reader.Close();
            _reader.Dispose();
        }
    }
}
