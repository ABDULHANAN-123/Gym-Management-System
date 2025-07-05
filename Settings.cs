using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace GYM_MANAGEMENT_SYSTEM
{
    public partial class Settings : Form
    {
        private string currentRole;
        OracleConnection con = new OracleConnection("User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;");
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please fill all password fields.");
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("New passwords do not match.");
                return;
            }

            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("SELECT Password FROM Admin WHERE Username = 'admin'", con);
                string currentPassword = cmd.ExecuteScalar()?.ToString();

                if (txtOldPassword.Text != currentPassword)
                {
                    MessageBox.Show("Incorrect old password.");
                    return;
                }

                OracleCommand updateCmd = new OracleCommand("UPDATE Admin SET Password = :newPass WHERE Username = 'admin'", con);
                updateCmd.Parameters.Add(":newPass", OracleDbType.Varchar2).Value = txtNewPassword.Text;
                updateCmd.ExecuteNonQuery();

                MessageBox.Show("Password changed successfully!");
                txtOldPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
                this.Hide();
            }
        }
    }
}
