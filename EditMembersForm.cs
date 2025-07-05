using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Oracle.ManagedDataAccess.Client;

namespace GYM_MANAGEMENT_SYSTEM
{
    public partial class EditMembersForm : Form
    {
    
        string ConnectionString = "User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;";
        private MemberManagementForm manageForm;
        private int memberId;
        private string currentRole;

        public EditMembersForm(int memberId, MemberManagementForm parentForm)
        {
            InitializeComponent();
            this.memberId = memberId;
            this.manageForm = parentForm;
        }

        private void EditMembersForm_Load(object sender, EventArgs e)
        {
            LoadPlans();
            LoadMemberDetails();
        }
        private void LoadPlans()
        {
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT PlanID, PlanName FROM Plans";
                OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbPlan.DataSource = dt;
                cmbPlan.DisplayMember = "PlanName";
                cmbPlan.ValueMember = "PlanID";
            }
        }

        private void LoadMemberDetails()
        {
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT Name, Contact, Address, Age, Gender, JoinDate, PlanID FROM Members WHERE MemberID = :id";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("id", memberId);

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtName.Text = reader["Name"].ToString();
                        txtContact.Text = reader["Contact"].ToString();
                        txtAddress.Text = reader["Address"].ToString();
                        numAge.Value = Convert.ToInt32(reader["Age"]);
                        cmbGender.Text = reader["Gender"].ToString();
                        dtpJoinDate.Value = Convert.ToDateTime(reader["JoinDate"]);
                        cmbPlan.SelectedValue = Convert.ToInt32(reader["PlanID"]);
                    }
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu("Admin");
            mainMenu.Show();
        }

        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Members 
                             SET Name = :name, Contact = :contact, Address = :address, 
                                 Age = :age, Gender = :gender, JoinDate = :joinDate, PlanID = :planId 
                             WHERE MemberID = :id";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("name", txtName.Text);
                    cmd.Parameters.Add("contact", txtContact.Text);
                    cmd.Parameters.Add("address", txtAddress.Text);
                    cmd.Parameters.Add("age", Convert.ToInt32(numAge.Value));
                    cmd.Parameters.Add("gender", cmbGender.Text);
                    cmd.Parameters.Add("joinDate", dtpJoinDate.Value);
                    cmd.Parameters.Add("planId", Convert.ToInt32(cmbPlan.SelectedValue));
                    cmd.Parameters.Add("id", memberId);  // make sure 'memberId' is a class-level variable

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Member updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the grid view in the original form
                    manageForm.LoadMembers();  // Ensure manageForm is passed to this form's constructor

                    this.Close();  // Close the edit form
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating member: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            MemberManagementForm memberManagementForm = new MemberManagementForm(currentRole);
            memberManagementForm.Show();
            this.Hide();
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
    