using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CCSPayrollBillingSystem.Scripts
{
    public class QueryProcessor
    {
        private string connectionString => SystemUtilities.GetConnectionString();
        private DatabaseConnection connection;
        private DatabaseCommand command;
        private DatabaseReader dataReader;

        #region SQL Process for Login
        //Searching on tblUser for Logging In
        public void ExecuteSqlLoginQuery(string username, string password, Action onSuccess, Action onFailure)
        {

            using (connection = new DatabaseConnection(connectionString))
            {
                string sql = "SELECT * FROM tblUser WHERE Username=@Username AND Password=@Password";

                using (command = new DatabaseCommand(sql, connection))
                {
                    command.AddParameter("@Username", username);
                    command.AddParameter("@Password", password);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            //EventManager.InvokeOnAdminLogged(username);
                           
                            MessageBox.Show("Hi - " + dataReader.GetValue(1));
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
            
            string sqlUpdate = "UPDATE tblUser SET Password='" + newPassword + "' WHERE Username='" + username + "'";

            connection = new DatabaseConnection(connectionString);
            command = new DatabaseCommand(sqlUpdate, connection);            
            dataReader = new DatabaseReader(command.ExecuteReader());
            if (dataReader.Read())
            {
                MessageBox.Show("Password Successfully Changed." + dataReader.GetValue(1));
            }
   
        }
        #endregion

        #region SQL Process for Change User EmpID for Admin only
        //Search for username
        public void ExecuteSqlSearchChangeUsersQuery(string username, int empID, Action onSuccess, Action onFailure)
        {
            string DEFAULT_PASSWORD = username;

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

            string sqlUpdate = "UPDATE tblUser SET EmpID= '" + empID + "',Password='" + password + "' WHERE Username='" + username + "'";

            connection = new DatabaseConnection(connectionString);
            command = new DatabaseCommand(sqlUpdate, connection);
            dataReader = new DatabaseReader(command.ExecuteReader());
            if (dataReader.Read())
            {
                MessageBox.Show(dataReader.GetValue(1)+"- User Successfully Changed.");
            }

        }
        #endregion

        #region SQL Process for Job CRUD Management
        //Search Validation for Inserting Jobs
        public void ExecuteSqlSearchValidationQuery(string jobTitle, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSearch = "SELECT * FROM tblJob WHERE JobTitle=@JobTitle";

                using (command = new DatabaseCommand(sqlSearch, connection))
                {
                    command.AddParameter("@JobTitle", jobTitle);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (!dataReader.Read())
                        {
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

        //Searching Records from tblJob
        public void ExecuteSqlSearchQuery(string jobTitle, Action<string, string, string, string> onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSearch = "SELECT * FROM tblJob WHERE JobTitle=@JobTitle";

                using (command = new DatabaseCommand(sqlSearch, connection))
                {
                    command.AddParameter("@JobTitle", jobTitle);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            onSuccess?.Invoke(dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), dataReader.GetValue(4).ToString());
                        }
                        else
                        {
                            onFailure?.Invoke();
                        }
                    }
                }
            }
        }

        //Insert tblJob
        public void ExecuteSqlSaveQuery(string jobTitle, string jobDescription, string jobRank, decimal jobPayRate)
        {
            string sqlInsert = "INSERT INTO tblJob VALUES('" + jobTitle + "','" + jobDescription + "','" + jobRank + "','" + jobPayRate + "')";

            connection = new DatabaseConnection(connectionString);
            command = new DatabaseCommand(sqlInsert, connection);
            dataReader = new DatabaseReader(command.ExecuteReader());
        }
        //Updating tblJob
        public void ExecuteSqlUpdateQuery(string jobTitle, string jobDescription, string jobRank, decimal jobPayRate)
        {

            string sqlUpdate = "UPDATE tblJob SET JobDescription='" + jobDescription + "', Rank='" + jobRank + "', PayRate='" + jobPayRate + "' WHERE JobTitle='" + jobTitle + "'";

            connection = new DatabaseConnection(connectionString);
            command = new DatabaseCommand(sqlUpdate, connection);
            dataReader = new DatabaseReader(command.ExecuteReader());
        }
        //Deleting tblJob
        public void ExecuteSqlDeleteQuery(string jobTitle, Action onSuccess, Action onFailure)
        {

            string sqlUpdate = "DELETE FROM tblJob WHERE JobTitle='" + jobTitle + "'";

            connection = new DatabaseConnection(connectionString);
            command = new DatabaseCommand(sqlUpdate, connection);
            dataReader = new DatabaseReader(command.ExecuteReader());
        }
        #endregion

        #region SQL Process for Deduction CRUD Management
        //Searching Records from tblJob
        public void ExecuteSqlSearchQueryForJobCombo(Action<Dictionary<string, string>> onSuccess, Action onFailure)
        {
            Dictionary<string,string> resultList = new Dictionary<string, string>();
            string sqlSearchForJobCombo = "SELECT JobID,JobTitle FROM tblJob";

            using (connection = new DatabaseConnection(connectionString))
            {
                command = new DatabaseCommand(sqlSearchForJobCombo, connection);
                dataReader = new DatabaseReader(command.ExecuteReader());
                while(dataReader.Read())
                {
                    string key = dataReader.GetValue(0).ToString();
                    string value = dataReader.GetValue(1).ToString();
                    resultList.Add(key,value);
                    Console.WriteLine(key +"-"+ value);
                }
                if (resultList.Count <= 0) onFailure.Invoke();
                onSuccess?.Invoke(resultList);
            }
        }
        
        //Search Validation for Inserting Deductions
        public void ExecuteSqlSearchValidationQuery(string deductionID, string jobID, Action onSuccess, Action onFailure)
        {

            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSearch = "SELECT * FROM tblDeductions WHERE JobID=@JobID";

                using (command = new DatabaseCommand(sqlSearch, connection))
                {
                    command.AddParameter("@DeductionID", deductionID);
                    command.AddParameter("@JobID", jobID);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (!dataReader.Read())
                        {
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

        //Searching Records from tblDeduction
        public void ExecuteSqlDeductionSearchQuery(string deductionID, string jobID, Action<string, string, string, string, string> onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSearch = "SELECT * FROM tblDeductions WHERE DeductionID=@DeductionID OR JobID=@JobID";

                using (command = new DatabaseCommand(sqlSearch, connection))
                {
                    command.AddParameter("@DeductionID", deductionID);
                    command.AddParameter("@JobID", jobID);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            onSuccess?.Invoke(dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), dataReader.GetValue(4).ToString(), dataReader.GetValue(5).ToString());
                        }
                        else
                        {
                            onFailure?.Invoke();
                        }
                    }
                }
            }
        }

        //Insert tblDeduction
        public void ExecuteSqlDeductionSaveQuery(string jobID, string sss, string pagibig, string philhealth, string tax)
        {
            string sqlInsert = "INSERT INTO tblDeductions(JobID, SSS, PagIbig, PhilHealth, Tax) VALUES('" + jobID + "','" + sss + "','" + pagibig + "','" + philhealth + "','" + tax + "')";

            connection = new DatabaseConnection(connectionString);
            command = new DatabaseCommand(sqlInsert, connection);
            dataReader = new DatabaseReader(command.ExecuteReader());
        }
        //Updating tblDeduction
        public void ExecuteSqlDeductionUpdateQuery(string deductionID, string jobID, string sss, string pagibig, string philhealth, string tax)
        {

            string sqlUpdate = "UPDATE tblDeductions SET SSS='" + sss + "', PagIbig='" + pagibig + "', PhilHealth='" + philhealth + "', Tax='" + tax + "' WHERE DeductionID='" + deductionID + "' AND JobID='" + jobID + "'";

            connection = new DatabaseConnection(connectionString);
            command = new DatabaseCommand(sqlUpdate, connection);
            dataReader = new DatabaseReader(command.ExecuteReader());
        }
        //Deleting tblDeduction
        public void ExecuteSqlDeductionDeleteQuery(string deductionID, string jobID, Action onSuccess, Action onFailure)
        {

            string sqlDelete = "DELETE FROM tblDeductions WHERE DeductionID='" + deductionID + "' AND JobID='" + jobID + "'";

            connection = new DatabaseConnection(connectionString);
            command = new DatabaseCommand(sqlDelete, connection);
            dataReader = new DatabaseReader(command.ExecuteReader());
        }
        #endregion

        //END......................
    }
}
