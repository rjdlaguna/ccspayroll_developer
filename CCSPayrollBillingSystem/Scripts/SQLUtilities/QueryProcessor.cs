using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

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

        //Check if there is/are Jobs in the table
        public int ExecuteSQLCountJobsQuery(Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSearch = "SELECT COUNT(*) FROM tblJob";

                using (command = new DatabaseCommand(sqlSearch, connection))
                {

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
                                               int jobID, int empStatus, Action onSuccess, Action onFailure)
        {
            string converted_bdate = birthdate.ToString("yyyy-MM-dd");
            string converted_datehired = datehired.ToString("yyyy-MM-dd");
            string converted_endofcontract = endofcontract.ToString("yyyy-MM-dd");
            string sqlInsert = "INSERT INTO tblEmployee(EmpFirstName,EmpMiddleName,EmpLastName,EmpHomeAddress,EmpContactNo,EmpBirthDate,EmploymentDate,EndOfContractDate,JobID,EmpStatus) "
                                + " VALUES('" + firstname + "','" + middlename + "','" + lastname + "','"
                                                                + homeaddress + "', '" + contactno + "','" + converted_bdate + "','"
                                                                + converted_datehired + "','" + converted_endofcontract + "','" + jobID + "','" +
                                                                +empStatus + "')";

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
        public void ExecuteSqlPayrollSaveQuery(PayrollData payrollData, WorkDays workDays, Action onSuccess, Action onFailure)
        {
            string sqlInsert = "INSERT INTO tblPayroll VALUES (@PayrollStartDate, @PayrollEndDate, @EmpID, @SSSAmount, @PagIbigAmount, @PhilHealthAmount, @GrossSalary, @NetSalary, @WorkDayID, @PayrollOthers)";

            using (connection = new DatabaseConnection(connectionString))
            {
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
                    command.AddParameter("@PayrollOthers", payrollData.PayrollOthers);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (!dataReader.Read())
                        {
                            onSuccess?.Invoke();
                            ExecuteSqlWorkDaySaveQuery(workDays);
                        }
                        else
                        {
                            onFailure?.Invoke();
                        }

                    }

                }
            }
        }
        public void ExecuteSqlWorkDaySaveQuery(WorkDays workDays)
        {

            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlWDInsert = "INSERT INTO tblWorkDays VALUES (" +
                    "@WorkDayID, @RegularDays, @RegularDaysOT, @SplHolidays, @SplHolidayOT, @RegularHoliday, @RegularHolidayOT, @RegHolRestDay, @COLA, @PDA, @Others)";

                using (command = new DatabaseCommand(sqlWDInsert, connection))
                {
                    // Add parameters with appropriate data types
                    command.AddParameter("@WorkDayID", workDays.WorkDayID);
                    command.AddParameter("@RegularDays", workDays.RegularDays);
                    command.AddParameter("@RegularDaysOT", workDays.RegularDaysOT);
                    command.AddParameter("@SplHolidays", workDays.SplHolidays);
                    command.AddParameter("@SplHolidayOT", workDays.SplHolidayOT);
                    command.AddParameter("@RegularHoliday", workDays.RegularHoliday);
                    command.AddParameter("@RegularHolidayOT", workDays.RegularHolidayOT);
                    command.AddParameter("@RegHolRestDay", workDays.RegHolRestDay);
                    command.AddParameter("@COLA", workDays.COLA);
                    command.AddParameter("@PDA", workDays.PDA);
                    command.AddParameter("@Others", workDays.Others);
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

        //Searching on tblPayroll
        public void ExecuteSqlPayrollSearchQuery(int empID, string from, string to, Action<PayrollData, WorkDays> onSuccess, Action onFailure)
        {
            string sqlSearch = "SELECT * FROM tblPayroll WHERE EmpID=@EmpID AND PayrollStartDate=@PayrollStartDate AND PayrollEndDate=@PayrollEndDate";
            

            using (connection = new DatabaseConnection(connectionString))
            using (command = new DatabaseCommand(sqlSearch, connection))
            {
                // Add parameters with appropriate data types
                command.AddParameter("@EmpID", empID);
                command.AddParameter("@PayrollStartDate", Convert.ToDateTime(from).Date);
                command.AddParameter("@PayrollEndDate", Convert.ToDateTime(to).Date);
                using (dataReader = new DatabaseReader(command.ExecuteReader()))
                {
                    if (dataReader.Read())
                    {
                        PayrollData payroll = new PayrollData();
                        payroll.Payroll_ID = (int)dataReader.GetValue(0);
                        payroll.PayrollStartDate = DateTime.Parse(dataReader.GetValue(1).ToString());
                        payroll.PayrollEndDate = DateTime.Parse(dataReader.GetValue(2).ToString());
                        payroll.EmpID = (int)dataReader.GetValue(3);

                        payroll.SSSAmount = dataReader.GetValue(4) == DBNull.Value ? 0M : Convert.ToDecimal(dataReader.GetValue(4).ToString());
                        payroll.PagIbigAmount = dataReader.GetValue(5) == DBNull.Value ? 0M : Convert.ToDecimal(dataReader.GetValue(5).ToString());
                        payroll.PhilHealthAmount = dataReader.GetValue(6) == DBNull.Value ? 0M : Convert.ToDecimal(dataReader.GetValue(6).ToString());
                        payroll.GrossSalary = dataReader.GetValue(7) == DBNull.Value ? 0M : Convert.ToDecimal(dataReader.GetValue(7).ToString());
                        payroll.NetSalary = dataReader.GetValue(8) == DBNull.Value ? 0M : Convert.ToDecimal(dataReader.GetValue(8).ToString());

                        payroll.WorkDayID = (int)dataReader.GetValue(9);
                        payroll.PayrollOthers = dataReader.GetValue(10) == DBNull.Value ? 0M : Convert.ToDecimal(dataReader.GetValue(10).ToString());

                        WorkDays work = ExecuteSqlWorkDaysQuery(payroll.WorkDayID);
                        onSuccess?.Invoke(payroll, work);
                    }
                    else
                    {
                        onFailure?.Invoke();
                    }

                }
            }
        }

        private WorkDays ExecuteSqlWorkDaysQuery(int id)
        {
            string sqlWorkDays = "SELECT * FROM tblWorkDays WHERE WorkDayID = @WorkDayID";


            using (connection = new DatabaseConnection(connectionString))
            using (command = new DatabaseCommand(sqlWorkDays, connection))
            {
                command.AddParameter("@WorkDayID", id);
                using (dataReader = new DatabaseReader(command.ExecuteReader()))
                {
                    if (dataReader.Read())
                    {
                        WorkDays work = new WorkDays();

                        work.WorkDayID = id;
                        work.RegularDays = dataReader.GetValue(1) == DBNull.Value ? 0f : float.Parse(dataReader.GetValue(1).ToString());
                        work.RegularDaysOT = dataReader.GetValue(2) == DBNull.Value ? 0f : float.Parse(dataReader.GetValue(2).ToString());
                        work.SplHolidays = dataReader.GetValue(3) == DBNull.Value ? 0f : float.Parse(dataReader.GetValue(3).ToString());
                        work.SplHolidayOT = dataReader.GetValue(4) == DBNull.Value ? 0f : float.Parse(dataReader.GetValue(4).ToString());
                        work.RegularHoliday = dataReader.GetValue(5) == DBNull.Value ? 0f : float.Parse(dataReader.GetValue(5).ToString());
                        work.RegularHolidayOT = dataReader.GetValue(6) == DBNull.Value ? 0f : float.Parse(dataReader.GetValue(6).ToString());
                        work.RegHolRestDay = dataReader.GetValue(7) == DBNull.Value ? 0f : float.Parse(dataReader.GetValue(7).ToString());
                        work.COLA = dataReader.GetValue(8) == DBNull.Value ? 0f : float.Parse(dataReader.GetValue(8).ToString());
                        work.PDA = dataReader.GetValue(9) == DBNull.Value ? 0f : float.Parse(dataReader.GetValue(9).ToString());
                        work.Others = dataReader.GetValue(10) == DBNull.Value ? 0f : float.Parse(dataReader.GetValue(10).ToString());

                        return work;
                    }
                    else
                    {
                        return null;
                    }

                }
            }

        }

        private EmployeePayrollData ExecuteSqlEmployeeQuery(int id)
        {
            string sqlWorkDays = "SELECT EmpID, EmpFirstName, EmpLastName, EmpMiddleName, JobID FROM tblEmployee WHERE EmpID='" + id + "'";

            using (connection = new DatabaseConnection(connectionString))
            using (command = new DatabaseCommand(sqlWorkDays, connection))
            using (dataReader = new DatabaseReader(command.ExecuteReader()))
            {
                if (dataReader.Read())
                {
                    EmployeePayrollData employeePayrollData = new EmployeePayrollData();
                    employeePayrollData.EmpID = id;
                    employeePayrollData.EmpFirstName = dataReader.GetValue(1).ToString();
                    employeePayrollData.EmpLastName = dataReader.GetValue(2).ToString();
                    employeePayrollData.EmpMiddleName = dataReader.GetValue(3).ToString();
                    employeePayrollData.JobID = int.Parse(dataReader.GetValue(4).ToString());

                    return employeePayrollData;
                }
                else
                {
                    return null;
                }

            }

        }

        private decimal ExecuteSqlJobRateQuery(int id)
        {
            string sqlJobRate = "SELECT PayRate FROM tblJob WHERE JobID='" + id + "'";
            decimal jobRate = 0M;

            using (connection = new DatabaseConnection(connectionString))
            using (command = new DatabaseCommand(sqlJobRate, connection))
            using (dataReader = new DatabaseReader(command.ExecuteReader()))
            {
                if (dataReader.Read())
                {
                    jobRate = dataReader.GetValue(0) == DBNull.Value ? 0M : Convert.ToDecimal(dataReader.GetValue(0).ToString());
                }

                return jobRate;
            }

        }

        public void ExecuteSqlPayrollAllSearchQuery(string from, string to, Action<List<PaySlipData>> onSuccess, Action onFailure)
        {
            List<PaySlipData> dataItems = new List<PaySlipData>();

            string sqlSearch = "SELECT * FROM tblPayroll WHERE PayrollStartDate=@PayrollStartDate AND PayrollEndDate=@PayrollEndDate";

            using (connection = new DatabaseConnection(connectionString))
            {
                using (command = new DatabaseCommand(sqlSearch, connection))
                {
                    // Add parameters with appropriate data types
                    command.AddParameter("@PayrollStartDate", Convert.ToDateTime(from).Date);
                    command.AddParameter("@PayrollEndDate", Convert.ToDateTime(to).Date);
                    sqlDataReader = command.ExecuteReader();
                    if(sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            PaySlipData _payslip = new PaySlipData();
                            PayrollData _paySlipPayrollData = new PayrollData();
                            WorkDays _paySlipWorkdays = new WorkDays();
                            EmployeePayrollData _employeePayrollData = new EmployeePayrollData();
                            decimal _jobRate = 0M;

                            _paySlipPayrollData.Payroll_ID = (int)sqlDataReader.GetValue(0);
                            _paySlipPayrollData.PayrollStartDate = DateTime.Parse(sqlDataReader.GetValue(1).ToString());
                            _paySlipPayrollData.PayrollEndDate = DateTime.Parse(sqlDataReader.GetValue(2).ToString());
                            _paySlipPayrollData.EmpID = (int)sqlDataReader.GetValue(3);

                            _paySlipPayrollData.SSSAmount = sqlDataReader.GetValue(4) == DBNull.Value ? 0M : Convert.ToDecimal(sqlDataReader.GetValue(4).ToString());
                            _paySlipPayrollData.PagIbigAmount = sqlDataReader.GetValue(5) == DBNull.Value ? 0M : Convert.ToDecimal(sqlDataReader.GetValue(5).ToString());
                            _paySlipPayrollData.PhilHealthAmount = sqlDataReader.GetValue(6) == DBNull.Value ? 0M : Convert.ToDecimal(sqlDataReader.GetValue(6).ToString());
                            _paySlipPayrollData.GrossSalary = sqlDataReader.GetValue(7) == DBNull.Value ? 0M : Convert.ToDecimal(sqlDataReader.GetValue(7).ToString());
                            _paySlipPayrollData.NetSalary = sqlDataReader.GetValue(8) == DBNull.Value ? 0M : Convert.ToDecimal(sqlDataReader.GetValue(8).ToString());

                            _paySlipPayrollData.WorkDayID = (int)sqlDataReader.GetValue(9);
                            _paySlipPayrollData.PayrollOthers = sqlDataReader.GetValue(10) == DBNull.Value ? 0M : Convert.ToDecimal(sqlDataReader.GetValue(10).ToString());

                            _paySlipWorkdays = ExecuteSqlWorkDaysQuery(_paySlipPayrollData.WorkDayID);
                            _employeePayrollData = ExecuteSqlEmployeeQuery(_paySlipPayrollData.EmpID);
                            _jobRate = ExecuteSqlJobRateQuery(_employeePayrollData.JobID);

                            _payslip.PayrollData = _paySlipPayrollData;
                            _payslip.WorkDays = _paySlipWorkdays;
                            _payslip.Employee = _employeePayrollData;
                            _payslip.PayRate = _jobRate;

                            dataItems.Add(_payslip);
                        }

                    }
                }
            }

            if (dataItems.Count > 0)
            {
                onSuccess?.Invoke(dataItems);
            }
            else
            {
                onFailure?.Invoke();
            }
        }

        

        public void ExecuteSqlPayrollUpdateQuery(PayrollData payrollData, WorkDays workDays, Action onSuccess, Action onFailure)
        {

            string sqlUpdatePayroll = "UPDATE tblPayroll SET PayrollStartDate=@PayrollStartDate, PayrollEndDate=@PayrollEndDate, EmpID=@EmpID, SSSAmount=@SSSAmount, " +
                "PagIbigAmount=@PagIbigAmount, PhilHealthAmount=@PhilHealthAmount, GrossSalary=@GrossSalary, NetSalary=@NetSalary, " +
                "WorkDayID=@WorkDayID, Tax=@PayrollOthers WHERE Payroll_ID=@Payroll_ID";

            using (connection = new DatabaseConnection(connectionString))
            {
                using (command = new DatabaseCommand(sqlUpdatePayroll, connection))
                {

                    // Add parameters with appropriate data types
                    command.AddParameter("@Payroll_ID", payrollData.Payroll_ID);
                    command.AddParameter("@PayrollStartDate", payrollData.PayrollStartDate);
                    command.AddParameter("@PayrollEndDate", payrollData.PayrollEndDate);
                    command.AddParameter("@EmpID", payrollData.EmpID);
                    command.AddParameter("@SSSAmount", payrollData.SSSAmount);
                    command.AddParameter("@PagIbigAmount", payrollData.PagIbigAmount);
                    command.AddParameter("@PhilHealthAmount", payrollData.PhilHealthAmount);
                    command.AddParameter("@GrossSalary", payrollData.GrossSalary);
                    command.AddParameter("@NetSalary", payrollData.NetSalary);
                    command.AddParameter("@WorkDayID", payrollData.WorkDayID);
                    command.AddParameter("@PayrollOthers", payrollData.PayrollOthers);
                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (!dataReader.Read())
                        {
                            ExecuteSqlWorkDaysUpdateQuery(workDays);
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
        public void ExecuteSqlWorkDaysUpdateQuery(WorkDays workDays)
        {
            string sqlUpdateWorkDays = "UPDATE tblWorkDays SET RegularDays=@RegularDays, RegularDaysOT=@RegularDaysOT, SplHolidays=@SplHolidays, SplHolidayOT=@SplHolidayOT, " +
                "RegularHoliday=@RegularHoliday, RegularHolidayOT=@RegularHolidayOT, RegHolRestDay=@RegHolRestDay, COLA=@COLA, PDA=@PDA, Others=@Others WHERE WorkDayID=@WorkDayID";

            using (connection = new DatabaseConnection(connectionString))
            {
                using (command = new DatabaseCommand(sqlUpdateWorkDays, connection))
                {
                    // Add parameters with appropriate data types
                    command.AddParameter("@WorkDayID", workDays.WorkDayID);
                    command.AddParameter("@RegularDays", workDays.RegularDays);
                    command.AddParameter("@RegularDaysOT", workDays.RegularDaysOT);
                    command.AddParameter("@SplHolidays", workDays.SplHolidays);
                    command.AddParameter("@SplHolidayOT", workDays.SplHolidayOT);
                    command.AddParameter("@RegularHoliday", workDays.RegularHoliday);
                    command.AddParameter("@RegularHolidayOT", workDays.RegularHolidayOT);
                    command.AddParameter("@RegHolRestDay", workDays.RegHolRestDay);
                    command.AddParameter("@COLA", workDays.COLA);
                    command.AddParameter("@PDA", workDays.PDA);
                    command.AddParameter("@Others", workDays.Others);
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

        public void ExecuteSqlPayrollDeleteQuery(int empID, int payrollID, int workdayID, Action onSuccess, Action onFailure)
        {

            string sqlDelete = "DELETE FROM tblPayroll WHERE Payroll_ID=@Payroll_ID AND EmpID=@EmpID AND WorkDayID=@WorkDayID";

            using (connection = new DatabaseConnection(connectionString))
            {
                using (command = new DatabaseCommand(sqlDelete, connection))
                {
                    command.AddParameter("@EmpID", empID);
                    command.AddParameter("@Payroll_ID", payrollID);
                    command.AddParameter("@WorkDayID", workdayID);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (!dataReader.Read())
                        {
                            ExecuteSqlWorkDaysDeleteQuery(workdayID);
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
        public void ExecuteSqlWorkDaysDeleteQuery(int workdayID)
        {

            string sqlDelete = "DELETE FROM tblWorkDays WHERE WorkDayID='" + workdayID + "'";

            connection = new DatabaseConnection(connectionString);
            command = new DatabaseCommand(sqlDelete, connection);
            dataReader = new DatabaseReader(command.ExecuteReader());
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

        public int ExecuteSQLCheckCountProjecrtsQuery(Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSearch = "SELECT COUNT(ProjectID) FROM tblProject WHERE IsActive = 1";

                using (command = new DatabaseCommand(sqlSearch, connection))
                {

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

        #region SQL Process for Billing Process

        public List<Dictionary<string, object>> ExecuteSqlBillingViewQuery(int projectID, DateTime dateTime)
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
                                    "LEFT JOIN tblWorkDays AS WORK ON PAY.WorkDayID = WORK.WorkDayID AND PAY.PayrollEndDate = @Date";
               

                using (command = new DatabaseCommand(sqlEPRDataSearch, connection))
                {
                    command.AddParameter("@Date", dateTime);

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
                                    "WORK.RegularDays AS 'Regular Days', WORK.RegularDaysOT AS 'Regular Days OT', WORK.SplHolidays AS 'Special Holidays', WORK.SplHolidayOT AS 'Special Holiday OT', WORK.RegularHoliday AS 'Regular Holiday', WORK.RegularHolidayOT AS 'Regular Holiday OT', WORK.RegHolRestDay AS 'Regular Holiday | Rest Day', WORK.COLA, WORK.PDA, WORK.Others " +
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

        #region SQL Process for Loan

        public void ExecuteSQLLoanDataSaveQuery(int empid, string desc, string type, decimal amount, Action onSuccess, Action onFailure)
        {
            decimal totalAmountPaid = 0.00M;
            string loanDate = DateTime.Now.ToString("yyyy-MM-dd");
            string sqlInsert = "INSERT INTO tblLoan(LoanDescription,LoanType,LoanAmount,LoanDate,EmpID,IsPaid) "
                                + " VALUES('" + desc + "','" + type + "','" + amount + "','" + loanDate + "','" + empid + "','" + 0 + "')";

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

        public void ExecuteSQLLoanDataViewQuery(int empId, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlLoanDataSearch = "";
                bool hasSearchValues = false;
                if (empId == 0 || empId == null)
                {
                    sqlLoanDataSearch = "SELECT L.LoanID as 'Loan ID', L.EmpID as 'Employee ID', E.EmpFirstName as 'First Name', E.EmpLastName as 'Last Name', LoanDescription as 'Description', LoanType as 'Loan Type', LoanAmount as 'Amount'," +
                                        "LoanDate as 'Loan Date', L.IsPaid as 'Is Paid' FROM tblLoan L LEFT JOIN tblEmployee E ON L.EmpID = E.EmpID";
                }
                else
                {
                    sqlLoanDataSearch = "SELECT  L.LoanID as 'Loan ID', L.EmpID as 'Employee ID', E.EmpFirstName as 'First Name', E.EmpLastName as 'Last Name', LoanDescription as 'Description', LoanType as 'Loan Type', LoanAmount as 'Amount'," +
                                        "LoanDate as 'Loan Date', L.IsPaid as 'Is Paid' FROM tblLoan L LEFT JOIN tblEmployee E ON L.EmpID = E.EmpID WHERE L.EmpID = @empId";
                    hasSearchValues = true;
                }


                using (command = new DatabaseCommand(sqlLoanDataSearch, connection))
                {
                    if (hasSearchValues)
                    {
                        command.AddParameter("@empId", empId);
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

        public void ExecuteSQLLoanPaymentListById(int loadId, Action onSuccess, Action onFailure)
        {

        }

        public int ExecuteSQLGetPayrollIDByPayrollDates(DateTime startDate, DateTime endDate, Action onSuccess, Action onFailure)
        {
            string sdate = startDate.ToString("yyyy-MM-dd");
            string edate = endDate.ToString("yyyy-MM-dd");
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSearch = "SELECT TOP 1 Payroll_ID FROM tblPayroll WHERE PayrollStartDate=@startDate AND PayrollEndDate=@endDate";

                using (command = new DatabaseCommand(sqlSearch, connection))
                {
                    command.AddParameter("@startDate", sdate);
                    command.AddParameter("@endDate", edate);

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

        public decimal ExecuteSQLComputeTotalAmountPaidForLoan(int loanId, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSumAmountPaid = "SELECT SUM(AmountToPay) FROM tblLoanPayment WHERE LoanID=@loanId";

                using (command = new DatabaseCommand(sqlSumAmountPaid, connection))
                {
                    command.AddParameter("@loanId", loanId);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            object result = dataReader.GetValue(0);
                            decimal decValue = 0.00M;
                            if (result != DBNull.Value)
                            {
                                decValue = (decimal)result;
                            }

                            onSuccess?.Invoke();
                            return decValue;
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

        public decimal ExecuteSQLComputeRemainingBalanceForLoan(int loanId, decimal loanAmount, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlSumAmountPaid = "SELECT SUM(AmountToPay) FROM tblLoanPayment WHERE LoanID=@loanId";

                using (command = new DatabaseCommand(sqlSumAmountPaid, connection))
                {
                    command.AddParameter("@loanId", loanId);

                    using (dataReader = new DatabaseReader(command.ExecuteReader()))
                    {
                        if (dataReader.Read())
                        {
                            object result = dataReader.GetValue(0);
                            decimal decValue = 0.00M;
                            if (result != DBNull.Value)
                            {
                                decValue = (decimal)result - loanAmount;
                            }

                            onSuccess?.Invoke();
                            return decValue;
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

        //Add Loan Payment
        public void ExecuteSQLLoanPaymentAdd(int loanId, int payrollId, decimal amountToPay, DateTime startDate, DateTime endDate, Action onSuccess, Action onFailure)
        {
            var loanPaymentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string sDate = startDate.ToString("yyyy-MM-dd");
            string eDate = endDate.ToString("yyyy-MM-dd");
            string sqlInsertLoanPaymentDetails = "INSERT INTO tblLoanPayment(LoanID,AmountToPay,DateOfPayment,PayrollStartDate,PayrollEndDate,PayrollID) " +
                                "VALUES('" + loanId + "','" + amountToPay + "','" + loanPaymentDate + "','" + sDate + "','" + eDate + "','" + payrollId + "')";

            connection = new DatabaseConnection(connectionString);
            command = new DatabaseCommand(sqlInsertLoanPaymentDetails, connection);
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

        // View Loan Payment List
        public void ExecuteSQLLoanPaymentDataViewQuery(int loanId, Action onSuccess, Action onFailure)
        {
            using (connection = new DatabaseConnection(connectionString))
            {
                string sqlLoanDataSearch = "";
                bool hasSearchValues = false;
                if (loanId == 0 || loanId == null)
                {
                    sqlLoanDataSearch = "SELECT AmountToPay as 'Amount Paid', DateOfPayment as 'Date of Payment', PayrollStartDate as 'Payroll Start Date', PayrollEndDate as 'Payrol Cutoff Date' " +
                                        "FROM tblLoanPayment";
                }
                else
                {
                    sqlLoanDataSearch = "SELECT AmountToPay as 'Amount Paid', DateOfPayment as 'Date of Payment', PayrollStartDate as 'Payroll Start Date', PayrollEndDate as 'Payrol Cutoff Date' " +
                                        "FROM tblLoanPayment WHERE LoanID = @loanId";
                    hasSearchValues = true;
                }


                using (command = new DatabaseCommand(sqlLoanDataSearch, connection))
                {
                    if (hasSearchValues)
                    {
                        command.AddParameter("@loanId", loanId);
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

        public void ExecuteSqlLoanIsPaidUpdateQuery(int loanId, Action onSuccess, Action onFailure)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlSearch = "UPDATE tblLoan SET IsPaid=1 WHERE LoanID = @loanId";

                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(sqlSearch, sqlConnection))
                {
                    command.Parameters.AddWithValue("@loanId", loanId);

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