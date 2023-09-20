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

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                DatabaseReader databaseReader = new DatabaseReader(sqlDataReader);

                string sqlSearch = "UPDATE tblEmployee SET EmpFirstName=@firstname,EmpMiddleName=@middlename,EmpLastName=@lastname," +
                                    "EmpHomeAddress=@homeaddress,EmpContactNo=@contactno,EmpBirthDate=@birthdate,EmploymentDate=@datehired," +
                                    "EndOfContractDate=@endofcontract,JobID=@jobID WHERE EmpID = @id";
                
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(sqlSearch, sqlConnection))
                {
                    command.Parameters.AddWithValue("@firstname",firstname);
                    command.Parameters.AddWithValue("@middlename", middlename);
                    command.Parameters.AddWithValue("@lastname", lastname);
                    command.Parameters.AddWithValue("@homeaddress", homeaddress);
                    command.Parameters.AddWithValue("@contactno", contactno);
                    command.Parameters.AddWithValue("@birthdate", birthdate);
                    command.Parameters.AddWithValue("@datehired", datehired);
                    command.Parameters.AddWithValue("@endofcontract", endofcontract);
                    command.Parameters.AddWithValue("@jobID", jobID);
                    command.Parameters.AddWithValue("@id", id);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        onSuccess?.Invoke();
                    }
                    else
                    {
                        onFailure?.Invoke();
                    }
                    sqlConnection.Close();

                }
            }
        }

        //Update Employee Status
        public void ExecuteSqlEmpStatusUpdateQuery(int id, Action onSuccess, Action onFailure)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlSearch = "UPDATE tblEmployee SET EmpStatus=0 WHERE EmpID = @id";

                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(sqlSearch, sqlConnection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        onSuccess?.Invoke();
                    }
                    else
                    {
                        onFailure?.Invoke();
                    }
                    sqlConnection.Close();
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

        public void ExecuteSqlWorkDaysValidationQuery(Action<int> onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSearch = "SELECT WorkDayID FROM tblWorkDays ORDER BY WorkDayID DESC";

                using (command = new DatabaseCommand(sqlSearch, connection))
                {
                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            onSuccess?.Invoke(Convert.ToInt32(dataReader.GetValue(0)));
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
        public void ExecuteSqlPayrollSaveQuery(PayrollData payrollData, Action onSuccess, Action onFailure)
        {
            string sqlInsert = "INSERT INTO tblPayroll VALUES (@PayrollStartDate, @PayrollEndDate, @EmpID, @SSSAmount, @PagIbigAmount, @PhilHealthAmount, @GrossSalary, @NetSalary, @WorkDayID, @Tax)";

            using (connection = new DatabaseConnection(connectionString))
            using (command = new DatabaseCommand(sqlInsert, connection))
            {
                // Add parameters with appropriate data types
                command.AddParameter("@PayrollStartDate", payrollData.PayrollStartDate);
                command.AddParameter("@PayrollEndDate", payrollData.PayrollEndDate);
                command.AddParameter("@EmpID", payrollData.EmpID);
                command.AddParameter("@SSSAmount", payrollData.SSSAmount);
                command.AddParameter("@PagIbigAmount", payrollData.PagIbigAmount);
                command.AddParameter("@PhilHealthAmount", payrollData.PhilHealthAmount);
                command.AddParameter("@GrossSalary", payrollData.GrossSalary);
                command.AddParameter("@NetSalary", payrollData.NetSalary);
                command.AddParameter("@WorkDayID", payrollData.WorkDayID);
                command.AddParameter("@Tax", payrollData.Tax);

                try
                {
                    dataReader = new DatabaseReader(command.ExecuteReader());

                    if (dataReader.Read())
                    {
                        onSuccess?.Invoke();
                    }
                    else
                    {
                        onFailure?.Invoke();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions, e.g., log or display error message
                    Console.WriteLine(ex);
                }

            }
        }
        public void ExecuteSqlWorkDaySaveQuery(WorkDays workDays, Action onSuccess, Action onFailure)
        {
            //string sqlWDInsert = "INSERT INTO tblWorkDays VALUES ('" + workDays.WorkDayID + "','" + workDays.RegularDays + "','" + workDays.RegularDaysOT + "','" +
            //    workDays.SplHolidays + "','" + workDays.SplHolidayOT + "','" + workDays.RegularHoliday + "','" + workDays.RegularHolidayOT + "','" + workDays.COLA + "','" + workDays.PDA + "','" + workDays.Others + "')";

            //using (connection = new DatabaseConnection(connectionString))
            //using (command = new DatabaseCommand(sqlWDInsert, connection))
            //{
            //    // Add parameters with appropriate data types
            //    command.AddParameter("@WorkDayID", workDays.WorkDayID);
            //    command.AddParameter("@RegularDays", workDays.RegularDays);
            //    command.AddParameter("@RegularDaysOT", workDays.RegularDaysOT);
            //    command.AddParameter("@SplHolidays", workDays.SplHolidays);
            //    command.AddParameter("@SplHolidayOT", workDays.SplHolidayOT);
            //    command.AddParameter("@RegularHoliday", workDays.RegularHoliday);
            //    command.AddParameter("@RegularHolidayOT", workDays.RegularHolidayOT);
            //    command.AddParameter("@COLA", workDays.COLA);
            //    command.AddParameter("@PDA", workDays.PDA);
            //    command.AddParameter("@Others", workDays.Others);

            //    dataReader = new DatabaseReader(command.ExecuteReader());

            //    if (dataReader.Read())
            //    {
            //        Console.WriteLine("Loading WorkDayID Information successful.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Problem loading WorkDay information.");
            //    }

               
            //}
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlWDInsert = "INSERT INTO tblWorkDays VALUES ('" + workDays.WorkDayID + "','" + workDays.RegularDays + "','" + workDays.RegularDaysOT + "','" +
                workDays.SplHolidays + "','" + workDays.SplHolidayOT + "','" + workDays.RegularHoliday + "','" + workDays.RegularHolidayOT + "','" + workDays.COLA + "','" + workDays.PDA + "','" + workDays.Others + "')"; ;

                using (command = new DatabaseCommand(sqlWDInsert, connection))
                {
                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            Console.WriteLine("Loading WorkDayID Information successful.");
                        }
                        else
                        {
                            Console.WriteLine("Problem loading WorkDay information.");
                        }
                    }
                }
            }

        }

            #endregion

            #region SQL Process for Project
            //Inserting data to tblProject
            public void ExecuteSQLProjectDataSaveQuery(string projName, string projDesc, string projAddress, string projInCharge, string projContactNo, string projEmail, Action onSuccess, Action onFailure)
        {
            int isActiveValue = 1;
            string sqlInsert = "INSERT INTO tblProject(ProjectName, ProjectDescription, ProjectAddress, PersonInCharge, ProjectContactNo, ProjectEmail, IsActive) " +
                                "VALUES ('" + projName + "','" + projDesc + "','" + projAddress + "', " +
                                 " '" + projInCharge + "','" + projContactNo + "','" + projEmail + "', '" + isActiveValue + "')";

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

        public void ExecuteSqlProjectDataViewQuery(string projName, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlProjectDataSearch = "";
                bool hasSearchValues = false;
                if (projName == null)
                {
                    sqlProjectDataSearch = "SELECT ProjectID as 'Project ID', ProjectName as 'Project Name', ProjectDescription as 'Description', ProjectAddress as 'Address'," +
                                        "PersonInCharge as 'Person In Charge', ProjectContactNo as 'Contact No.', ProjectEmail as 'Email'" +
                                        " FROM tblProject WHERE IsActive = 1";
                }
                else
                {
                    sqlProjectDataSearch = "SELECT ProjectID as 'Project ID', ProjectName as 'Project Name', ProjectDescription as 'Description', ProjectAddress as 'Address'," +
                                        "PersonInCharge as 'Person In Charge', ProjectContactNo as 'Contact No.', ProjectEmail as 'Email'" +
                                        " FROM tblProject WHERE ProjectName = @projectname AND IsActive = 1";
                    hasSearchValues = true;
                }


                using (command = new DatabaseCommand(sqlProjectDataSearch, connection))
                {
                    if (hasSearchValues)
                    {
                        command.AddParameter("@projectname", projName);
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

        public List<string[]> ExecuteSqlLoadProjectsQuery(Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                List<string[]> projectList = new List<string[]>();
                string sqlLoadProjects = "SELECT ProjectID, ProjectName FROM tblProject";

                using (command = new DatabaseCommand(sqlLoadProjects, connection))
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

                            projectList.Add(row);
                        }
                        onSuccess?.Invoke();
                        return projectList;
                    }
                    else
                    {
                        onFailure?.Invoke();
                        return null;
                    }
                }
            }

        }

        public int ExecuteSQLCheckEmployeeExist(string fname, string lname, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlEmpDataSearch = "";
                if (!String.IsNullOrEmpty(fname) || !String.IsNullOrEmpty(lname))
                {
                    sqlEmpDataSearch = "SELECT EmpID FROM tblEmployee " +
                                        "WHERE EmpFirstName = @firstname OR EmpLastName = @lastname AND EmpStatus = 1";
                }

                using (command = new DatabaseCommand(sqlEmpDataSearch, connection))
                {
                    command.AddParameter("@firstname", fname);
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

        public void ExecuteSQLAddEmployeeToProject(int empId, int projId, decimal projRate, Action onSuccess, Action onFailure)
        {
            string sqlInsert = "INSERT INTO tblEPR(EmpID,ProjectID,ProjectRate) "
                                + " VALUES('" + empId + "','" + projId + "','" + projRate + "')";

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

        public void ExecuteSQLLoadProjectEmployeesQuery(int projId, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlEmpProjectDataSearch = "";

                sqlEmpProjectDataSearch = "SELECT E.EmpFirstName as 'First Name', E.EmpMiddleName as 'Middle Name', E.EmpLastName as 'Last Name', EP.ProjectRate as 'Project Rate', " +
                                    "(SELECT J.JobTitle from tblJob J WHERE J.JobID = E.JobID) AS 'Job Title' from tblEmployee E " +
                                    "INNER JOIN tblEPR EP ON EP.EmpID = E.EmpID AND EP.ProjectID = @projId";

                using (command = new DatabaseCommand(sqlEmpProjectDataSearch, connection))
                {

                    command.AddParameter("@projId", projId);

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

        public List<Dictionary<string, object>> ExecuteSqlBillingViewQuery(int projectID)
        {
            List<Dictionary<string, object>> resultRows = new List<Dictionary<string, object>>();

            string sqlEPRDataSearch = string.Empty;
            using (connection = new DatabaseConnection(connectionString))
            {
                sqlEPRDataSearch = "SELECT EMP.EmpID AS 'Employee ID', EMP.EmpFirstName AS 'FirstName', EMP.EmpLastName AS 'LastName', PROJ.ProjectName AS 'ProjectName', EPR.ProjectRate AS 'ProjectRate', " +
                                    "WORK.RegularDays AS 'Regular Days', WORK.RegularDaysOT AS 'Regular Days OT', WORK.SplHolidays AS 'Special Holidays', WORK.SplHolidayOT AS 'Special Holiday OT', WORK.RegularHoliday AS 'Regular Holiday', WORK.RegularHolidayOT AS 'Regular Holiday OT', WORK.COLA, WORK.PDA, WORK.Others " +
                                    "FROM tblEPR AS EPR " +
                                    "INNER JOIN tblEmployee AS EMP ON EPR.EmpID = EMP.EmpID " +
                                    "INNER JOIN tblProject AS PROJ ON EPR.ProjectID = PROJ.ProjectID " +
                                    "INNER JOIN tblPayroll AS PAY ON EPR.EmpID = PAY.EmpID " +
                                    "LEFT JOIN tblWorkDays AS WORK ON PAY.WorkDayID = WORK.WorkDayID ";

                using (command = new DatabaseCommand(sqlEPRDataSearch, connection))
                {
                    sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Dictionary<string, object> row = new Dictionary<string, object>();
                            for (int i = 0; i < sqlDataReader.FieldCount; i++)
                            {
                                string columnName = sqlDataReader.GetName(i);
                                object columnValue = sqlDataReader[i];
                                row[columnName] = columnValue;
                            }
                            resultRows.Add(row);
                        }

                    }
                    
                }
               
            }
            return resultRows;
        }

        public void ExecuteSqlBillingViewQuery4DataGrid(int projectID, Action onSuccess, Action onFailure)
        {
            string sqlEPRDataSearch = string.Empty;
            using (connection = new DatabaseConnection(connectionString))
            {
                sqlEPRDataSearch = "SELECT EMP.EmpID AS 'Employee ID', EMP.EmpFirstName AS 'FirstName', EMP.EmpLastName AS 'LastName', PROJ.ProjectName AS 'ProjectName', EPR.ProjectRate AS 'ProjectRate', " +
                                    "WORK.RegularDays AS 'Regular Days', WORK.RegularDaysOT AS 'Regular Days OT', WORK.SplHolidays AS 'Special Holidays', WORK.SplHolidayOT AS 'Special Holiday OT', WORK.RegularHoliday AS 'Regular Holiday', WORK.RegularHolidayOT AS 'Regular Holiday OT', WORK.COLA, WORK.PDA, WORK.Others " +
                                    "FROM tblEPR AS EPR " +
                                    "INNER JOIN tblEmployee AS EMP ON EPR.EmpID = EMP.EmpID " +
                                    "INNER JOIN tblProject AS PROJ ON EPR.ProjectID = PROJ.ProjectID " +
                                    "INNER JOIN tblPayroll AS PAY ON EPR.EmpID = PAY.EmpID " +
                                    "LEFT JOIN tblWorkDays AS WORK ON PAY.WorkDayID = WORK.WorkDayID ";

                using (command = new DatabaseCommand(sqlEPRDataSearch, connection))
                {
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
        
        public void ExecuteSqlBillingInsertQuery(DateTime billingStartDate, DateTime billingEndDate, decimal billingGrossTotal, decimal vat, int projectID, decimal billingNetTotal, Action onSuccess, Action onFailure)
        {
            string sqlInsert = "INSERT INTO tblBilling (BillingStartDate, BillingEndDate, BillingGrossTotal, ComputedTax, ProjectID, BillingNetTotal) VALUES (@BillingStartDate, @BillingEndDate, @BillingGrossTotal, @Vat, @ProjectID, @BillingNetTotal)";

            using (connection = new DatabaseConnection(connectionString))
            using (command = new DatabaseCommand(sqlInsert, connection))
            {
                // Add parameters with appropriate data types
                command.AddParameter("@BillingStartDate", billingStartDate);
                command.AddParameter("@BillingEndDate", billingEndDate);
                command.AddParameter("@BillingGrossTotal", billingGrossTotal);
                command.AddParameter("@Vat", vat);
                command.AddParameter("@ProjectID", projectID);
                command.AddParameter("@BillingNetTotal", billingNetTotal);

                try
                {
                    dataReader = new DatabaseReader(command.ExecuteReader());

                    if (dataReader.Read())
                    {
                        onSuccess?.Invoke();
                    }
                    else
                    {
                        onFailure?.Invoke();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions, e.g., log or display error message
                    Console.WriteLine("Error: " + ex.Message);
                    onFailure?.Invoke();
                }
            }


        }

        public void ExecuteSqlProjectDataUpdate(int projID, string projName, string projDesc, string projAddress, string projInCharge, string projContact, string projEmail, Action onSuccess, Action onFailure)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlProjectUpdate = "UPDATE tblProject SET ProjectName=@projectname, ProjectDescription=@projectdesc, " +
                                          "ProjectAddress=@projectaddress, PersonInCharge=@projectincharge, ProjectContactNo=@projectcontact, " +
                                          "ProjectEmail=@projectemail WHERE ProjectID=@projId";

                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(sqlProjectUpdate, sqlConnection))
                {
                    command.Parameters.AddWithValue("@projId", projID);
                    command.Parameters.AddWithValue("@projectname", projName);
                    command.Parameters.AddWithValue("@projectdesc", projDesc);
                    command.Parameters.AddWithValue("@projectaddress", projAddress);
                    command.Parameters.AddWithValue("@projectincharge", projInCharge);
                    command.Parameters.AddWithValue("@projectcontact", projContact);
                    command.Parameters.AddWithValue("@projectemail", projEmail);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        onSuccess?.Invoke();
                    }
                    else
                    {
                        onFailure?.Invoke();
                    }
                    sqlConnection.Close();

                }
            }
        }
        // Update Project Status
        public void ExecuteSqlProjectStatusUpdateQuery(int id, Action onSuccess, Action onFailure)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlProjectSearch = "UPDATE tblProject SET IsActive=0 WHERE ProjectID = @id";

                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(sqlProjectSearch, sqlConnection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        onSuccess?.Invoke();
                    }
                    else
                    {
                        onFailure?.Invoke();
                    }
                    sqlConnection.Close();
                }
            }
        }

        #endregion

        #region //Formatting retrieved employee into a table
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
        #endregion
        //END......................
    }
}