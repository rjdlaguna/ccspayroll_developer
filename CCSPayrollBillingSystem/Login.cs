using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System;
using CCSPayrollBillingSystem.Scripts;

namespace CCSPayrollBillingSystem
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (ValidateInput())
            {
                ExecuteSqlQuery(username, password, () =>
                {
                    // Successful login action
                    FormMain formMain = new FormMain();
                    this.Hide();
                    formMain.ShowDialog();
                }, () =>
                {
                    // Failed login action
                    MessageBox.Show("No Accounts Available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
            else
            {
                MessageBox.Show("Please Fill the Required Fields Correctly!");
            }

        }
        private bool ValidateInput()
        {
            return !string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text);
        }
        private void ExecuteSqlQuery(string username, string password, Action onSuccess, Action onFailure)
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

    }
}

//        FormMain formMain = new FormMain();

//        string connetionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=db_PayrollBilling;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//        SqlConnection cnn = new SqlConnection(connetionString);
//        cnn.Open();

//            if (txtUsername.Text != string.Empty || txtPassword.Text != string.Empty) {
//                string sql = "SELECT * FROM tblUser WHERE Username='" + txtUsername.Text + "'AND Password='" + txtPassword.Text + "'";

//        SqlCommand command = new SqlCommand(sql, cnn);
//        SqlDataReader dataReader = command.ExecuteReader();


//                if (dataReader.Read())
//                {
//                    MessageBox.Show("Hi! " + dataReader.GetValue(1));
//                    dataReader.Close();
//                    this.Hide();
//        formMain.ShowDialog();
//                }
//                else
//                {
//                    dataReader.Close();
//                    MessageBox.Show("No Accounts Available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }


//command.Dispose();
//cnn.Close();
//            }
//            else
//{
//    MessageBox.Show("Please Fill the Required Fields!");
//}
//SELECT QUERY STRUCTURE

//string sql = "Select * from tblUser";

//SqlCommand command = new SqlCommand(sql, cnn);
//SqlDataReader dataReader = command.ExecuteReader();

//while (dataReader.Read())
//{
//    Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) +"-"+ dataReader.GetValue(2) + " - " + dataReader.GetValue(3) + " - " + dataReader.GetValue(4) + "\n";
//}

//MessageBox.Show("Connection Open !\n"+ Output);

