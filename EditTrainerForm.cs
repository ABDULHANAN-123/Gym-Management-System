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
    public partial class EditTrainerForm : Form
    {
        string ConnectionString = "User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;";
        private int trainerId;
        private TrainerManagementForm manageForm;

        public EditTrainerForm(int trainerId, TrainerManagementForm parentForm)
        {
            InitializeComponent();
            this.trainerId = trainerId;
            manageForm = parentForm;
        }
        public EditTrainerForm() // Default constructor if needed
        {
            InitializeComponent();
        }
        private void EditTrainerForm_Load(object sender, EventArgs e)
        {
            LoadTrainerDetails();
            txtTrainerID.ReadOnly = true; // Make TrainerID read-only
        }
        private void LoadTrainerDetails()
        {
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string selectQuery = "SELECT Name, Specialization, CONTACT_NUMBER, Email, JOINDATE, EXPERIENCEYEARS FROM Trainers WHERE TrainerID = :trainerId";
                    using (OracleCommand cmd = new OracleCommand(selectQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":trainerId", OracleDbType.Int32)).Value = trainerId;
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTrainerID.Text = trainerId.ToString();
                                txtName.Text = reader["Name"].ToString();
                                txtSpecialization.Text = reader["Specialization"].ToString();
                                txtContactNo.Text = reader["CONTACT_NUMBER"].ToString(); // Use uppercase
                                txtEmail.Text = reader["Email"].ToString();
                                txtExperianceYears.Text = reader["EXPERIENCEYEARS"].ToString();
                                dtpJoinDate.Value = Convert.ToDateTime(reader["JOINDATE"]); // Use uppercase
                            }
                            else
                            {
                                MessageBox.Show("Trainer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading trainer details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtSpecialization.Text) ||
                string.IsNullOrWhiteSpace(txtContactNo.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill in all the trainer details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string updateQuery = @"UPDATE Trainers
                       SET Name = :name,
                           Specialization = :specialization,
                           CONTACT_NUMBER = :contact,
                           Email = :email,
                           JOINDATE = :joinDate, 
                           EXPERIENCEYEARS = :experianceYears 
                       WHERE TrainerID = :trainerId";
                    using (OracleCommand cmd = new OracleCommand(updateQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":name", OracleDbType.Varchar2)).Value = txtName.Text.Trim();
                        cmd.Parameters.Add(new OracleParameter(":specialization", OracleDbType.Varchar2)).Value = txtSpecialization.Text.Trim();
                        cmd.Parameters.Add(new OracleParameter(":contact", OracleDbType.Varchar2)).Value = txtContactNo.Text.Trim(); 
                        cmd.Parameters.Add(new OracleParameter(":email", OracleDbType.Varchar2)).Value = txtEmail.Text.Trim();
                        cmd.Parameters.Add(new OracleParameter(":joinDate", OracleDbType.Date)).Value = dtpJoinDate.Value;
                        cmd.Parameters.Add(new OracleParameter(":experianceYears", OracleDbType.Int32)).Value = int.TryParse(txtExperianceYears.Text.Trim(), out int years) ? years : (object)DBNull.Value; 
                        cmd.Parameters.Add(new OracleParameter(":trainerId", OracleDbType.Int32)).Value = trainerId;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Trainer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            manageForm?.LoadTrainers(); // Refresh the trainer list in the main form
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update trainer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating trainer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
