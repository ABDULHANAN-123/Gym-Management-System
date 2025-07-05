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
    public partial class DeleteMembersForm : Form
    {
        string ConnectionString = "User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;";
        private MemberManagementForm manageForm; // To refresh the member list
        private string currentRole;
        public DeleteMembersForm(MemberManagementForm parentForm, string Role)
        {
            InitializeComponent();
            manageForm = parentForm;
            this.currentRole = Role;
        }
        public DeleteMembersForm() // Default constructor if no parent is passed
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string memberIdToDeleteText = txtMemberId.Text.Trim();
            string nameToDelete = txtName.Text.Trim();

            if (string.IsNullOrEmpty(memberIdToDeleteText) && string.IsNullOrEmpty(nameToDelete))
            {
                MessageBox.Show("Please enter either the Member ID or the Name of the member to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string deleteQuery = "DELETE FROM Members WHERE ";
            OracleParameter parameter;

            if (!string.IsNullOrEmpty(memberIdToDeleteText))
            {
                deleteQuery += "MemberID = :memberId";
                parameter = new OracleParameter(":memberId", OracleDbType.Int32);
                if (int.TryParse(memberIdToDeleteText, out int memberIdValue))
                {
                    parameter.Value = memberIdValue;
                }
                else
                {
                    MessageBox.Show("Invalid Member ID. Please enter a numeric value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else // !string.IsNullOrEmpty(nameToDelete)
            {
                deleteQuery += "Name = :name";
                parameter = new OracleParameter(":name", OracleDbType.Varchar2);
                parameter.Value = nameToDelete;
            }

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.Add(parameter);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Member deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            manageForm?.LoadMembers(); // Refresh the member list if manageForm is available
                            this.Close();
                            MemberManagementForm memberManagementForm = new MemberManagementForm(currentRole);
                            memberManagementForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("No member found with the specified criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting member: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMemberID_TextChanged(object sender, EventArgs e)
        {
            // Auto-load member name when MemberID is typed
            if (string.IsNullOrWhiteSpace(txtMemberId.Text))
            {
                txtName.Clear();
                return;
            }

           
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Name FROM Members WHERE MemberID = :id";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(new OracleParameter("id", txtMemberId.Text));

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtName.Text = reader["Name"].ToString();
                    }
                    else
                    {
                        txtName.Text = "(Not Found)";
                    }
                }
                catch
                {
                    txtName.Text = "(Error)";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemberManagementForm memberForm = new MemberManagementForm(currentRole);
            memberForm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
                this.Hide();
            }
        }

        private void DeleteMembersForm_Load(object sender, EventArgs e)
        {

        }
    }
}

