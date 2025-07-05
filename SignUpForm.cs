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
    public partial class SignUpForm : Form
    {
        string ConnectionString = "User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;";

        public SignUpForm()
        {
            InitializeComponent();
            LoadRoles();
        }
        public SignUpForm(string role)
        {
            InitializeComponent();
            LoadRoles();
            if (!cmbRole.Items.Contains(role))
                cmbRole.Items.AddRange(new string[] { "Admin", "Trainee", "Trainer", "Manager", "Receptionist", "Accountant" });

            cmbRole.SelectedItem = role;
            cmbRole.Enabled = false; // Disable so user can't change it
        }
        private void LoadRoles()
        {
            // This function is called in both constructors to ensure ComboBox is always populated
            if (cmbRole.Items.Count == 0) // To prevent adding duplicate items
            {
                cmbRole.Items.AddRange(new string[] { "Admin", "Trainee", "Trainer", "Manager", "Receptionist", "Accountant" });
            }
        }
        private void SignUpForm_Load(object sender, EventArgs e)
        {
            LoadRoles();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
             string.IsNullOrWhiteSpace(txtUsername.Text) ||
             string.IsNullOrWhiteSpace(txtPass.Text) ||
             string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("All fields are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPass.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role.", "Missing Role", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedRole = cmbRole.SelectedItem.ToString();

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    // Check for existing email
                    string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE UserEmail = :useremail";
                    using (OracleCommand checkEmailCmd = new OracleCommand(checkEmailQuery, conn))
                    {
                        checkEmailCmd.Parameters.Add(new OracleParameter("useremail", txtEmail.Text));
                        int emailCount = Convert.ToInt32(checkEmailCmd.ExecuteScalar());
                        if (emailCount > 0)
                        {
                            MessageBox.Show("This email is already registered.");
                            return;
                        }
                    }

                    // Check for existing username
                    string checkUsernameQuery = "SELECT COUNT(*) FROM Users WHERE Username = :username";
                    using (OracleCommand checkUsernameCmd = new OracleCommand(checkUsernameQuery, conn))
                    {
                        checkUsernameCmd.Parameters.Add(new OracleParameter("username", txtUsername.Text));
                        int usernameCount = Convert.ToInt32(checkUsernameCmd.ExecuteScalar());
                        if (usernameCount > 0)
                        {
                            MessageBox.Show("This username is already taken.");
                            return;
                        }
                    }

                    // Admin uniqueness
                    if (selectedRole == "Admin")
                    {
                        string checkAdminQuery = "SELECT COUNT(*) FROM Users WHERE LOWER(Role) = 'admin'";
                        using (OracleCommand checkCmd = new OracleCommand(checkAdminQuery, conn))
                        {
                            int adminCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                            if (adminCount >= 1)
                            {
                                MessageBox.Show("An Admin already exists.");
                                return;
                            }
                        }
                    }
                    if (selectedRole == "Manager")
                    {
                        string checkManagerQuery = "SELECT COUNT(*) FROM Users WHERE LOWER(Role) = 'manager'";
                        using (OracleCommand checkCmd = new OracleCommand(checkManagerQuery, conn))
                        {
                            int managerCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                            if (managerCount >= 1)
                            {
                                MessageBox.Show("A Manager already exists.");
                                return;
                            }
                        }
                    }
                    // Registration
                    string insertQuery = "INSERT INTO Users (UserEmail, Username, Password, Role) VALUES (:useremail, :username, :password, :role)";
                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("useremail", txtEmail.Text));
                        cmd.Parameters.Add(new OracleParameter("username", txtUsername.Text));
                        cmd.Parameters.Add(new OracleParameter("password", txtPass.Text));
                        cmd.Parameters.Add(new OracleParameter("role", selectedRole));

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Sign Up Successful! Please log in.");

                        LogInForm loginForm = new LogInForm();
                        this.Hide();
                        loginForm.ShowDialog();
                        this.Close();
                    }
                }
                catch (OracleException ex)
                {
                    if (ex.Number == 1)
                        MessageBox.Show("This email or username is already registered.");
                    else
                        MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }
    }
}
