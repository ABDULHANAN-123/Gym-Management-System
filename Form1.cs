using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GYM_MANAGEMENT_SYSTEM;
using Oracle.ManagedDataAccess.Client;

namespace ATM_FINAL
{
    public partial class MainPage : Form
    {
        string ConnectionString = "User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;";
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load (object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //signup button:
        private void button1_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
            this.Hide();
        }
        //login button:
        private void button2_Click(object sender, EventArgs e)
        {
            LogInForm loginForm = new LogInForm();
            loginForm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

