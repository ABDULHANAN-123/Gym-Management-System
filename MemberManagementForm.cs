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
    public partial class MemberManagementForm : Form
    {
        string ConnectionString = "User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;";
        private int memberId;
        private string currentRole;

        public MemberManagementForm(string currentRole)
        {
            InitializeComponent();
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.MultiSelect = false;
            LoadMembers();
            this.currentRole = currentRole;
        }

      

        private void MemberManagementForm_Load(object sender, EventArgs e)
        {
            LoadMembers();
        }

        public void LoadMembers(string filter = "")
        {
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Members";
                    List<string> conditions = new List<string>();
                    List<OracleParameter> parameters = new List<OracleParameter>();

                    if (!string.IsNullOrEmpty(filter))
                    {
                        // Get the columns of the Members table
                        using (OracleCommand cmdColumns = new OracleCommand("SELECT column_name FROM all_tab_columns WHERE table_name = 'MEMBERS'", conn))
                        using (OracleDataReader reader = cmdColumns.ExecuteReader())
                        {
                            int parameterCounter = 0;
                            while (reader.Read())
                            {
                                string columnName = reader["column_name"].ToString();
                                // Add a condition for each column (you might want to exclude certain columns like dates if direct string matching isn't suitable)
                                conditions.Add($"{columnName} LIKE :filter{parameterCounter}");
                                parameters.Add(new OracleParameter($":filter{parameterCounter}", OracleDbType.Varchar2) { Value = "%" + filter + "%" });
                                parameterCounter++;
                            }
                        }

                        if (conditions.Count > 0)
                        {
                            query += " WHERE " + string.Join(" OR ", conditions);
                        }
                    }

                    OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddRange(parameters.ToArray());

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvMembers.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load members: " + ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMembers(txtFilter.Text.Trim());
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            addmembers addForm = new addmembers(this, currentRole);
            addForm.Show();
            LoadMembers(); // Refresh
        }

        private void btnEditMember_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0)
            {
                int memberId = Convert.ToInt32(dgvMembers.SelectedRows[0].Cells["MemberID"].Value);
                EditMembersForm edit = new EditMembersForm(memberId, this); // Pass member ID and this form
                edit.Show();
                this.Hide();
                MemberManagementForm manageForm = new MemberManagementForm(currentRole);
                manageForm.Show(); // Refresh
            }
            else
            {
                MessageBox.Show("Please select a member to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0)
                return;

            int memberId = Convert.ToInt32(dgvMembers.SelectedRows[0].Cells["MemberID"].Value);

            if (MessageBox.Show("Delete this member?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (OracleConnection conn = new OracleConnection(ConnectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("DELETE FROM Members WHERE MemberID = :id", conn))
                    {
                        cmd.Parameters.Add(":id", memberId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadMembers(); // Refresh
            }
            
        }

        private void btnAddMember_Click_1(object sender, EventArgs e)
        {
            addmembers addForm = new addmembers(this,currentRole);
            addForm.Owner = this;
            addForm.Show();
            this.Hide();
        }

        private void btnEditMember_Click_1(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0)
            {
                int memberId = Convert.ToInt32(dgvMembers.SelectedRows[0].Cells["MemberID"].Value);

                // Create and show the edit form
                EditMembersForm edit = new EditMembersForm(memberId, this);
                edit.Owner = this;
                edit.Show(); // modal dialog
                this.Hide();
                LoadMembers(); // Refresh grid

            }
            else
            {
                MessageBox.Show("Please select a member to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteMember_Click_1(object sender, EventArgs e)
        {
            DeleteMembersForm del = new DeleteMembersForm(this,currentRole);
            del.Owner = this;
            del.Show(); // Modal
            this.Hide();
            LoadMembers(); // Refresh after delete

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            LoadMembers(txtFilter.Text.Trim());
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
                this.Hide();
            }

        }
    }
}
