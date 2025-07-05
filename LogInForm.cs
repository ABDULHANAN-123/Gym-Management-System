using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATM_FINAL;
using Oracle.ManagedDataAccess.Client;

namespace GYM_MANAGEMENT_SYSTEM
{
    public partial class LogInForm : Form
    {
        string ConnectionString = "User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;";

        public LogInForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT Role FROM Users WHERE UserEmail = :email AND Password = :password";
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(new OracleParameter("email", txtEmail.Text));
                cmd.Parameters.Add(new OracleParameter("password", txtPass.Text));

                object roleObj = cmd.ExecuteScalar(); // Get the role

                if (roleObj != null)
                {
                    string role = roleObj.ToString();
                    MessageBox.Show("Login Successful!");

                    MainMenu main = new MainMenu(role); // Pass role to MainMenu
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid ID or Password!");
                }
            }
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainPage form1 = new MainPage();
            form1.Show();
            this.Hide();
        }
    }
}
