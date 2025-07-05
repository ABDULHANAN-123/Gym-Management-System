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
    public partial class PlanManagementForm : Form
    {
        string ConnectionString = "User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;";
        private string currentRole;
        public PlanManagementForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void PlanManagementForm_Load(object sender, EventArgs e)
        {
            dgvPlans.AutoGenerateColumns = false;
            dgvPlans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlans.AllowUserToAddRows = false;
            dgvPlans.AllowUserToDeleteRows = false;

            if (dgvPlans.Columns.Count == 0)
            {
                DataGridViewTextBoxColumn planIdColumn = new DataGridViewTextBoxColumn { Name = "PlanID", HeaderText = "Plan ID", DataPropertyName = "PlanID", ReadOnly = true };
                DataGridViewTextBoxColumn planNameColumn = new DataGridViewTextBoxColumn { Name = "PlanName", HeaderText = "Plan Name", DataPropertyName = "PlanName" };
                DataGridViewTextBoxColumn durationColumn = new DataGridViewTextBoxColumn { Name = "DurationMonths", HeaderText = "Duration (Months)", DataPropertyName = "DurationMonths" };
                DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Price", DataPropertyName = "Price" };

                dgvPlans.Columns.AddRange(planIdColumn, planNameColumn, durationColumn, priceColumn);
            }
            LoadPlans();
        }

        private void LoadPlans()
        {
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT PlanID, PlanName, DurationMonths, Price FROM Plans\r\n";
                    OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvPlans.DataSource = dt;
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error loading plans: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void ClearInputFields()
        {
            txtPlanID.Text = "";
            txtName.Text = "";
            numDurationMonths.Value = 1;
            txtPrice.Text = "";
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlanID.Text))
            {
                MessageBox.Show("Please select a plan to update or use the Add button to insert a new plan.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter plan name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (numDurationMonths.Value <= 0)
            {
                MessageBox.Show("Please enter a valid duration (greater than 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDurationMonths.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price (greater than 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            int planId = Convert.ToInt32(txtPlanID.Text);

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Plans 
                             SET PlanName = :planName, 
                                 DurationMonths = :duration, 
                                 Price = :price
                             WHERE PlanID = :planId";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":planName", OracleDbType.Varchar2).Value = txtName.Text.Trim();
                        cmd.Parameters.Add(":duration", OracleDbType.Int32).Value = (int)numDurationMonths.Value;
                        cmd.Parameters.Add(":price", OracleDbType.Decimal).Value = price;
                        cmd.Parameters.Add(":planId", OracleDbType.Int32).Value = planId;

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Plan updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadPlans();
                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Plan not found or update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error updating plan: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPlans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPlans.Rows[e.RowIndex];

                // Check if PlanID cell contains DBNull (null) before attempting to convert
                if (row.Cells["PlanID"].Value != DBNull.Value)
                {
                    txtName.Text = row.Cells["PlanName"].Value.ToString();
                    numDurationMonths.Value = Convert.ToInt32(row.Cells["DurationMonths"].Value);
                    txtPrice.Text = row.Cells["Price"].Value.ToString();

                    // Safely cast PlanID value to integer
                    int planId = Convert.ToInt32(row.Cells["PlanID"].Value);
                    txtPlanID.Text = planId.ToString();  // Or use it for other logic
                }
                else
                {
                    MessageBox.Show("The selected row does not contain a valid Plan ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter plan name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (numDurationMonths.Value <= 0)
            {
                MessageBox.Show("Please enter a valid duration (greater than 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDurationMonths.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price (greater than 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO Plans (PlanID, PlanName, DurationMonths, Price) VALUES (PLANS_SEQ.NEXTVAL, :planName, :duration, :price)";
                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":planName", OracleDbType.Varchar2)).Value = txtName.Text.Trim();
                        cmd.Parameters.Add(new OracleParameter(":duration", OracleDbType.Int32)).Value = (int)numDurationMonths.Value;
                        cmd.Parameters.Add(new OracleParameter(":price", OracleDbType.Decimal)).Value = price;

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Plan added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPlans();
                        ClearInputFields();
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error adding plan: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPlans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a plan to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter plan name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (numDurationMonths.Value <= 0)
            {
                MessageBox.Show("Please enter a valid duration (greater than 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDurationMonths.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price (greater than 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            int planId = Convert.ToInt32(dgvPlans.SelectedRows[0].Cells["PlanID"].Value);

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string updateQuery = @"UPDATE Plans 
                                           SET PlanName = :planName, 
                                               DurationMonths = :duration, 
                                               Price = :price
                                           WHERE PlanID = :planId";
                    using (OracleCommand cmd = new OracleCommand(updateQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":planName", OracleDbType.Varchar2)).Value = txtName.Text.Trim();
                        cmd.Parameters.Add(new OracleParameter(":duration", OracleDbType.Int32)).Value = (int)numDurationMonths.Value;
                        cmd.Parameters.Add(new OracleParameter(":price", OracleDbType.Decimal)).Value = price;
                        cmd.Parameters.Add(new OracleParameter(":planId", OracleDbType.Int32)).Value = planId;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Plan updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadPlans();
                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update plan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error updating plan: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPlans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a plan to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int planId = Convert.ToInt32(dgvPlans.SelectedRows[0].Cells["PlanID"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to delete this plan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (OracleConnection conn = new OracleConnection(ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM Plans WHERE PlanID = :planId";
                        using (OracleCommand cmd = new OracleCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.Add(new OracleParameter(":planId", OracleDbType.Int32)).Value = planId;

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Plan deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadPlans();
                                ClearInputFields();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete plan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    catch (OracleException ex)
                    {
                        MessageBox.Show("Error deleting plan: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter plan name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (numDurationMonths.Value <= 0)
            {
                MessageBox.Show("Please enter a valid duration (greater than 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDurationMonths.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price (greater than 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO Plans (PlanID, PlanName, DurationMonths, Price) VALUES (PLANS_SEQ.NEXTVAL, :planName, :duration, :price)";
                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":planName", OracleDbType.Varchar2)).Value = txtName.Text.Trim();
                        cmd.Parameters.Add(new OracleParameter(":duration", OracleDbType.Int32)).Value = (int)numDurationMonths.Value;
                        cmd.Parameters.Add(new OracleParameter(":price", OracleDbType.Decimal)).Value = price;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Plan added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPlans();         // Refresh DataGridView with updated data
                        ClearInputFields();  // Reset input fields
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error adding plan: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           if(this.Owner!=null)
            {
                this.Owner.Show();
                this.Hide();
            }
        }
    }
}

