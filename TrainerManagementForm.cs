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
    public partial class TrainerManagementForm : Form
    {
        string ConnectionString = "User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;";
        private string currentRole;
        public TrainerManagementForm(string currentRole)
        {
            InitializeComponent();
            this.currentRole = currentRole;
        }

        private void TrainerManagementForm_Load(object sender, EventArgs e)
        {
            dgvTrainers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrainers.MultiSelect = false;
            LoadTrainers();
        }
       

        public void LoadTrainers(string filter = "")
        {
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT TrainerID, Name, Specialization, CONTACT_NUMBER, Email, JOINDATE,EXPERIENCEYEARS FROM Trainers"; // Make sure ALL desired columns are listed here

                    if (!string.IsNullOrEmpty(filter))
                    {
                        query += " WHERE Name LIKE :filter OR Specialization LIKE :filter OR CONTACT_NUMBER LIKE :filter OR Email LIKE :filter OR JOINDATE LIKE :filter OR EXPERIENCEYEARS LIKE :filter"; // Add other columns if you want to filter by them
                    }

                    OracleDataAdapter adapter = new OracleDataAdapter(query, conn);

                    if (!string.IsNullOrEmpty(filter))
                    {
                        adapter.SelectCommand.Parameters.Add(new OracleParameter(":filter", OracleDbType.Varchar2)).Value = "%" + filter + "%";
                    }

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvTrainers.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load trainers: " + ex.Message);
                }
            }
        }

        

        private void dgvTrainers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddTrainers_Click(object sender, EventArgs e)
        {
            AddTrainerForm addTrainerForm = new AddTrainerForm(this); // Pass this form for refresh
            addTrainerForm.Owner = this;
            addTrainerForm.Show();
            this.Hide();
        }

        private void btnEditTrainers_Click(object sender, EventArgs e)
        {
            if (dgvTrainers.SelectedRows.Count > 0)
            {
                int trainerId = Convert.ToInt32(dgvTrainers.SelectedRows[0].Cells["TrainerID"].Value);
                EditTrainerForm editTrainerForm = new EditTrainerForm(trainerId, this); // Pass trainer ID and this form
                editTrainerForm.Owner = this;
                editTrainerForm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Please select a trainer to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteTrainers_Click(object sender, EventArgs e)
        {
            if (dgvTrainers.SelectedRows.Count > 0)
            {
                int trainerId = Convert.ToInt32(dgvTrainers.SelectedRows[0].Cells["TrainerID"].Value);
                string trainerName = dgvTrainers.SelectedRows[0].Cells["Name"].Value.ToString();

                if (MessageBox.Show($"Are you sure you want to delete trainer '{trainerName}' (ID: {trainerId})?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (OracleConnection conn = new OracleConnection(ConnectionString))
                    {
                        try
                        {
                            conn.Open();
                            string deleteQuery = "DELETE FROM Trainers WHERE TrainerID = :trainerId";
                            using (OracleCommand cmd = new OracleCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.Add(new OracleParameter(":trainerId", OracleDbType.Int32)).Value = trainerId;
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Trainer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadTrainers(); // Refresh the list
                                }
                                else
                                {
                                    MessageBox.Show("Failed to delete trainer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting trainer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a trainer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            LoadTrainers(txtFilter.Text.Trim());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           if(this.Owner != null)
            {
                this.Owner.Show();
                this.Hide();
            }
        }
    }
}
