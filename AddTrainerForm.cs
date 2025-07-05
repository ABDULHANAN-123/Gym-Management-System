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
    public partial class AddTrainerForm : Form
    {
        string ConnectionString = "User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;";
        private TrainerManagementForm manageForm;
        public AddTrainerForm(TrainerManagementForm parentForm)
        {
            InitializeComponent();
            manageForm = parentForm;
        }
        public AddTrainerForm() // Default constructor if needed
        {
            InitializeComponent();
        }
        private void AddTrainerForm_Load(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtSpecialization.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text) ||
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
                    string insertQuery = @"INSERT INTO Trainers (TrainerID, Name, Specialization, CONTACT_NUMBER, Email, JOINDATE, ExperienceYears)
                                       VALUES (TRAINER_SEQ.NEXTVAL, :name, :specialization, :contact, :email, :joinDate, :experianceYears)";
                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":name", OracleDbType.Varchar2)).Value = txtName.Text.Trim();
                        cmd.Parameters.Add(new OracleParameter(":specialization", OracleDbType.Varchar2)).Value = txtSpecialization.Text.Trim();
                        cmd.Parameters.Add(new OracleParameter(":contact", OracleDbType.Varchar2)).Value = txtContact.Text.Trim();
                        cmd.Parameters.Add(new OracleParameter(":email", OracleDbType.Varchar2)).Value = txtEmail.Text.Trim();
                        cmd.Parameters.Add(new OracleParameter(":joinDate", OracleDbType.Date)).Value = dtpJoinDate.Value;
                        cmd.Parameters.Add(new OracleParameter(":experianceYears", OracleDbType.Int32)).Value = int.TryParse(txtExperianceYears.Text.Trim(), out int years) ? years : (object)DBNull.Value;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Trainer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            manageForm?.LoadTrainers(); // Refresh the trainer list in the main form
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add trainer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding trainer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
