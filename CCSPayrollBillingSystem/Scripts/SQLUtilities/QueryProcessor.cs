using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace CCSPayrollBillingSystem.Scripts
{
    public class QueryProcessor
    {
        private string connectionString => SystemUtilities.GetConnectionString();
        private DatabaseConnection connection;
        private DatabaseCommand command;
        private DatabaseReader dataReader;
        private SqlDataReader sqlDataReader;

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
                MessageBox.Show(dataReader.GetValue(1) + "- User Successfully Changed.");
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

        //Loading All Job Title
        public List<string[]> ExecuteSqlLoadJobsQuery(Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                List<string[]> jobList = new List<string[]>();
                string sqlLoadJobs = "SELECT JobID, JobTitle FROM tblJob";

                using (command = new DatabaseCommand(sqlLoadJobs, connection))
                {
                    sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            string[] row = new string[sqlDataReader.FieldCount];

                            for (int i = 0; i < sqlDataReader.FieldCount; i++)
                            {
                                row[i] = sqlDataReader[i].ToString();
                            }

                            jobList.Add(row);
                        }
                        onSuccess?.Invoke();
                        return jobList;
                    }
                    else
                    {
                        onFailure?.Invoke();
                        return null;
                    }
                }
            }

        }

        //Searching for JobID by Job Title
        public int ExecuteSqlFindJobID(string title, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSearch = "SELECT JobID FROM tblJob WHERE JobTitle=@jobtitle";

                using (command = new DatabaseCommand(sqlSearch, connection))
                {
                    command.AddParameter("@jobtitle", title);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            object result = dataReader.GetValue(0);
                            int intValue = (int)result;

                            onSuccess?.Invoke();
                            return intValue;
                        }
                        else
                        {
                            onFailure?.Invoke();
                            return 0;
                        }
                    }
                }
            }

        }
        #endregion

        #region SQL Process for Deduction CRUD Management
        //Searching Records from tblJob
        public void ExecuteSqlSearchQueryForJobCombo(Action<Dictionary<string, string>> onSuccess, Action onFailure)
        {
            Dictionary<string, string> resultList = new Dictionary<string, string>();
            string sqlSearchForJobCombo = "SELECT JobID,JobTitle FROM tblJob";

            using (connection = new DatabaseConnection(connectionString))
            {
                command = new DatabaseCommand(sqlSearchForJobCombo, connection);
                dataReader = new DatabaseReader(command.ExecuteReader());
                while (dataReader.Read())
                {
                    string key = dataReader.GetValue(0).ToString();
                    string value = dataReader.GetValue(1).ToString();
                    resultList.Add(key, value);
                    Console.WriteLine(key + "-" + value);
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

        //Search for the Deduction ID of an Employee
        public int ExecuteSQLGetDeductionIDbyJobID(int jobID, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSearch = "SELECT DeductionID FROM tblDeductions WHERE JobID=@JobID";

                using (command = new DatabaseCommand(sqlSearch, connection))
                {
                    command.AddParameter("@JobID", jobID);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            object result = dataReader.GetValue(0);
                            int intValue = (int)result;

                            onSuccess?.Invoke();
                            return intValue;
                        }
                        else
                        {
                            onFailure?.Invoke();
                            return 0;
                        }
                    }
                }
            }
        }

        #endregion

        #region SQL Process for Employees
        // Inserting Employee Data to tblEmployee
        public void ExecuteSqlEmpDataSaveQuery(string firstname, string middlename, string lastname, string homeaddress,
                                               string contactno, DateTime birthdate, DateTime datehired, DateTime endofcontract,
                                               int jobID, int empStatus, int deductionID, Action onSuccess, Action onFailure)
        {
            string sqlInsert = "INSERT INTO tblEmployee(EmpFirstName,EmpMiddleName,EmpLastName,EmpHomeAddress,EmpContactNo,EmpBirthDate,EmploymentDate,EndOfContractDate,JobID,EmpStatus,DeductionID) "
                                + " VALUES('" + firstname + "','" + middlename + "','" + lastname + "','"
                                                                + homeaddress + "', '" + contactno + "','" + birthdate + "','"
                                                                + datehired + "','" + endofcontract + "','" + jobID + "','" +
                                                                +empStatus + "','" + deductionID + "')";

            connection = new DatabaseConnection(connectionString);
            command = new DatabaseCommand(sqlInsert, connection);
            dataReader = new DatabaseReader(command.ExecuteReader());

            if (!dataReader.Read())
            {
                onSuccess?.Invoke();
            }
            else
            {
                onFailure?.Invoke();
            }
        }

        //Loading All Employees and Searching Specific Employee
        public void ExecuteSqlEmpDataViewQuery(string fname, string lname, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlEmpDataSearch = "";
                bool hasSearchValues = false;
                if (fname == null && lname == null)
                {
                    sqlEmpDataSearch = "SELECT EmpID as 'Employee ID', EmpFirstName as 'First Name', EmpMiddleName as 'Middle Name', EmpLastName as 'Last Name'," +
                                        "EmpHomeAddress as 'Home Address', EmpContactNo as 'Contact No.', EmpBirthDate as 'Date of Birth'," +
                                        "EmploymentDate as 'Date Hired', EndOfContractDate as 'End of Contract' FROM tblEmployee WHERE EmpStatus = 1";
                }
                else
                {
                    sqlEmpDataSearch = "SELECT EmpID as 'Employee ID', EmpFirstName as 'First Name', EmpMiddleName as 'Middle Name', EmpLastName as 'Last Name'," +
                                        "EmpHomeAddress as 'Home Address', EmpContactNo as 'Contact No.', EmpBirthDate as 'Date of Birth'," +
                                        "EmploymentDate as 'Date Hired', EndOfContractDate as 'End of Contract' FROM tblEmployee " +
                                        "WHERE EmpFirstName = @firstname OR EmpLastName = @lastname AND EmpStatus = 1";
                    hasSearchValues = true;
                }


                using (command = new DatabaseCommand(sqlEmpDataSearch, connection))
                {
                    if (hasSearchValues)
                    {
                        command.AddParameter("@firstname", fname);
                        command.AddParameter("@lastname", lname);
                    }

                    sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
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

        //Get JobID via First Name, Middle Name and Last Name
        public int ExecuteSQLGetJobIDThruEmployeeData(string fname, string mname, string lname, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSearch = "SELECT JobID FROM tblEmployee WHERE EmpFirstName=@firstname AND EmpMiddleName=@middlename AND EmpLastName=@lastname";

                using (command = new DatabaseCommand(sqlSearch, connection))
                {
                    command.AddParameter("@firstname", fname);
                    command.AddParameter("@middlename", mname);
                    command.AddParameter("@lastname", lname);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            object result = dataReader.GetValue(0);
                            int intValue = (int)result;

                            onSuccess?.Invoke();
                            return intValue;
                        }
                        else
                        {
                            onFailure?.Invoke();
                            return 0;
                        }
                    }
                }
            }
        }

        //Update Employee Data modified
        public void ExecuteSqlEmpDataUpdate(int id, string firstname, string middlename, string lastname, string homeaddress,
                                               string contactno, DateTime birthdate, DateTime datehired, DateTime endofcontract,
                                               int jobID, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSearch = "UPDATE tblEmployee SET EmpFirstName=@firstname,EmpMiddleName=@middlename,EmpLastName=@lastname," +
                                    "EmpHomeAddress=@homeaddress,EmpContactNo=@contactno,EmpBirthDate=@birthdate,EmploymentDate=@datehired," +
                                    "EndOfContractDate=@endofcontract,JobID=@jobID WHERE EmpID = @id";

                using (command = new DatabaseCommand(sqlSearch, connection))
                {
                    command.AddParameter("@id", id);
                    command.AddParameter("@firstname", firstname);
                    command.AddParameter("@middlename", middlename);
                    command.AddParameter("@lastname", lastname);
                    command.AddParameter("@homeaddress", homeaddress);
                    command.AddParameter("@contactno", contactno);
                    command.AddParameter("@birthdate", birthdate);
                    command.AddParameter("@datehired", datehired);
                    command.AddParameter("@endofcontract", endofcontract);
                    command.AddParameter("@jobID", jobID);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
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

        //Update Employee Status
        public void ExecuteSqlEmpStatusUpdateQuery(int id, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSearch = "UPDATE tblEmployee SET EmpStatus=0 WHERE EmpID = @id";

                using (command = new DatabaseCommand(sqlSearch, connection))
                {
                    command.AddParameter("@id", id);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
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

        #endregion

        #region SQL Process for Payroll Information
        public void ExecuteSqlPayrollEmpLoadInfoQuery(string fname, string lname, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlPayrollInfoSearch = "";
                bool hasSearchValues = false;
                if (fname == null && lname == null)
                {
                    sqlPayrollInfoSearch = "SELECT E.EmpID, E.EmpLastName, E.EmpFirstName, " +
                                            "J.JobTitle, J.PayRate, J.Rank from tblEmployee " +
                                            "E LEFT JOIN tblJob J ON E.JobID = J.JobID " +
                                            "WHERE E.EmpStatus = 1 ORDER BY E.EmpLastName";
                }
                else
                {
                    sqlPayrollInfoSearch = "SELECT E.EmpID, E.EmpLastName, E.EmpFirstName, " +
                                            "J.JobTitle, J.PayRate, J.Rank from tblEmployee " +
                                            "E LEFT JOIN tblJob J ON E.JobID = J.JobID " +
                                            "WHERE E.EmpStatus = 1 AND E.EmpFirstName = @firstname AND E.EmpLastName = @lastname";
                    hasSearchValues = true;
                }


                using (command = new DatabaseCommand(sqlPayrollInfoSearch, connection))
                {
                    if (hasSearchValues)
                    {
                        command.AddParameter("@firstname", fname);
                        command.AddParameter("@lastname", lname);
                    }

                    sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
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

        #endregion

        #region SQL Process for Billing Process

        public void ExecuteSqlBillingViewQuery(int projectID, Action onSuccess, Action onFailure)
        {
            string sqlEmpDataSearch = string.Empty;
            using (connection = new DatabaseConnection(connectionString))
            {
                sqlEmpDataSearch = "SELECT EmpID FROM tblEPR WHERE ProjectID = @ProjectID";

                using (command = new DatabaseCommand(sqlEmpDataSearch, connection))
                {
                    command.AddParameter("@ProjectID", projectID);

                    sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        onSuccess?.Invoke();
                    }
                    else
                    {
                        onFailure?.Invoke();
                    }

                }
            }
            #endregion
            //END......................
        }

        //Formatting retrieved employee into a table
        public DataTable GetSqlReaderData()
        {
            DataTable dataTable = new DataTable();

            for (int i = 0; i < sqlDataReader.FieldCount; i++)
            {
                string columnName = sqlDataReader.GetName(i);
                Type columnType = sqlDataReader.GetFieldType(i);
                dataTable.Columns.Add(columnName, columnType);
            }

            while (sqlDataReader.Read())
            {
                DataRow row = dataTable.NewRow();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    row[i] = sqlDataReader[i];
                }
                dataTable.Rows.Add(row);
            }
            sqlDataReader.Close();

            return dataTable;
        }
    }
}
