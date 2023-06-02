using System.Windows.Forms;

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
            formLogin formLogin = new formLogin();
            db_CCSPayrollBillingEntities db_Entities = new db_CCSPayrollBillingEntities();
            
            //if (txtUsername.Text!=string.Empty || txtPassword.Text!= string.Empty)
            //{
            //    var userName = db_Entities.tblUsers.Find(txtUsername.Text);
            //    var passWord = db_Entities.tblUsers.Find(txtPassword.Text);
            //    if (userName == null)
            //    {
            //        MessageBox.Show("Null Values");
            //    }
            //    else
            //    {
            //        if (userName.Equals(txtUsername.Text) && passWord.Equals(txtPassword.Text))
            //        {
            //            formLogin.Hide();
            //            formMain.Show();
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please Enter Username and Password!");
            //}

            formMain.Show();
        }
    }
}
