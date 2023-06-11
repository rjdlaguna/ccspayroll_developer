using System;
using System.Windows.Forms;

namespace CCSPayrollBillingSystem.Scripts
{
    public class QueryProcessor
    {
        #region SQL Process for Login
        //Searching on tblUser for Logging In
        public void ExecuteSqlLoginQuery(string username, string password, Action onSuccess, Action onFailure)
        {
            string connectionString = SystemUtilities.GetConnectionString();

            using (DatabaseConnection connection = new DatabaseConnection(connectionString))
            {
                string sql = "SELECT * FROM tblUser WHERE Username=@Username AND Password=@Password";

                using (DatabaseCommand command = new DatabaseCommand(sql, connection))
                {
                    command.AddParameter("@Username", username);
                    command.AddParameter("@Password", password);

                    using (DatabaseReader dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            //EventManager.InvokeOnAdminLogged(username);
                           
                            MessageBox.Show("Hi! " + dataReader.GetValue(1));
                            onSuccess?.Invoke();
                        }
                        else
                        {
                            onFailure?.Invoke();
                        }
                    }
                }
            }
        }
        #endregion

        #region SQL Process for Change Password
        //Search for Username
        public void ExecuteSqlSearchChangePasswordQuery(string username, string currentPassword, string newPassword, string confirmPassword, Action onSuccess, Action onFailure)
        {
            string connectionString = SystemUtilities.GetConnectionString();
            DatabaseConnection connection;
            DatabaseCommand command;
            DatabaseReader dataReader;
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlChangeSearch = "SELECT * FROM tblUser WHERE Username=@Username AND Password=@Password";

                using (command = new DatabaseCommand(sqlChangeSearch, connection))
                {
                    command.AddParameter("@Username", username);
                    command.AddParameter("@Password", currentPassword);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read() && newPassword == confirmPassword)
                        {
                            ExecuteSqlUpdatePasswordQuery(username, newPassword);
                            onSuccess?.Invoke();
                        }
                        else
                        {
                            onFailure?.Invoke();
                        }
                    }
                }
            }
        }

        //Updating tblUser for New Password
        private void ExecuteSqlUpdatePasswordQuery(string username, string newPassword)
        {
            DatabaseConnection connection;
            DatabaseCommand command;
            DatabaseReader dataReader;
            
            string sqlUpdate = "UPDATE tblUser SET Password='" + newPassword + "' WHERE Username='" + username + "'";

            string connectionString = SystemUtilities.GetConnectionString();

            connection = new DatabaseConnection(connectionString);
            command = new DatabaseCommand(sqlUpdate, connection);            
            dataReader = new DatabaseReader(command.ExecuteReader());
            if (dataReader.Read())
            {
                MessageBox.Show("Password Successfully Changed!" + dataReader.GetValue(1));
            }
   
        }
        #endregion

        #region SQL Process for Change User EmpID for Admin only
        //Search for username
        public void ExecuteSqlSearchChangeUsersQuery(string username, int empID, Action onSuccess, Action onFailure)
        {
            string DEFAULT_PASSWORD = username;
            string connectionString = SystemUtilities.GetConnectionString();
            DatabaseConnection connection;
            DatabaseCommand command;
            DatabaseReader dataReader;
            using (connection = new DatabaseConnection(connectionString))
            {
                string sql = "SELECT * FROM tblUser WHERE Username=@Username";

                using (command = new DatabaseCommand(sql, connection))
                {
                    command.AddParameter("@Username", username);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            ExecuteSqlUpdateChangeUserQuery(username, empID, DEFAULT_PASSWORD);
                            onSuccess?.Invoke();
                        }
                        else
                        {
                            onFailure?.Invoke();
                        }
                    }
                }
            }
        }
        //Updating the tblUser on EmpID
        private void ExecuteSqlUpdateChangeUserQuery(string username, int empID, string password)
        {
            DatabaseConnection connection;
            DatabaseCommand command;
            DatabaseReader dataReader;

            string sqlUpdate = "UPDATE tblUser SET EmpID= '" + empID + "',Password='" + password + "' WHERE Username='" + username + "'";

            string connectionString = SystemUtilities.GetConnectionString();

            connection = new DatabaseConnection(connectionString);
            command = new DatabaseCommand(sqlUpdate, connection);
            dataReader = new DatabaseReader(command.ExecuteReader());
            if (dataReader.Read())
            {
                MessageBox.Show(dataReader.GetValue(1)+"- User Successfully Changed!");
            }

        }
        #endregion


        //END......................
    }
}
