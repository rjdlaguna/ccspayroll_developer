using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

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
            FormMain formMain = new FormMain();

            string connetionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=db_PayrollBilling;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();

            string sql = "SELECT * FROM tblUser WHERE Username='"+txtUsername.Text+"'AND Password='"+txtPassword.Text+"'";

            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                MessageBox.Show("Hi! " + dataReader.GetValue(1));
                dataReader.Close();
                this.Hide();
                formMain.ShowDialog();
            }
            else
            {
                dataReader.Close();
                MessageBox.Show("No Accounts Available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            command.Dispose();
            cnn.Close();
        
        }
        //SELECT QUERY STRUCTURE

        //string sql = "Select * from tblUser";

        //SqlCommand command = new SqlCommand(sql, cnn);
        //SqlDataReader dataReader = command.ExecuteReader();

        //while (dataReader.Read())
        //{
        //    Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) +"-"+ dataReader.GetValue(2) + " - " + dataReader.GetValue(3) + " - " + dataReader.GetValue(4) + "\n";
        //}

        //MessageBox.Show("Connection Open !\n"+ Output);
    }
}
