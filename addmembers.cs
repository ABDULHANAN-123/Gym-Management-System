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
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;


namespace GYM_MANAGEMENT_SYSTEM
{
    public partial class addmembers : Form
    {
        string ConnectionString = "User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;";
        private MemberManagementForm manageForm;
        private string currentRole;
        public addmembers()
        {
            InitializeComponent();
        }

        public addmembers(MemberManagementForm parentForm, string currentRole)
        {
            InitializeComponent();
            manageForm = parentForm;
            this.currentRole = currentRole;
        }

        private void addmembers_Load(object sender, EventArgs e)
        {
            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT PlanID, PlanName FROM Plans";
                    OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbPlan.DataSource = dt;
                    cmbPlan.DisplayMember = "PlanName";   // Show PlanName in ComboBox
                    cmbPlan.ValueMember = "PlanID";       // Store PlanID as value
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading plans: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Members 
                        (MemberID, Name, Contact, Address, Age, Gender, PlanID) 
                        VALUES (MEMBER_SEQ.NEXTVAL, :name, :contact, :address, :age, :gender, :planid)";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("name", txtName.Text);
                    cmd.Parameters.Add("contact", txtContact.Text);
                    cmd.Parameters.Add("address", txtAddress.Text);
                    cmd.Parameters.Add("age", Convert.ToInt32(numAge.Value));
                    cmd.Parameters.Add("gender", cmbGender.SelectedItem.ToString());
                    cmd.Parameters.Add("planid", Convert.ToInt32(cmbPlan.SelectedValue));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Member added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    manageForm.LoadMembers();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
          if (txtName.Text == "" || txtContact.Text == "" || txtAddress.Text == "" ||
        cmbGender.SelectedItem == null || string.IsNullOrWhiteSpace(cmbPlan.Text))
            {
                MessageBox.Show("Please fill all fields before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Check if the plan exists
                    string checkPlanQuery = "SELECT PlanID FROM Plans WHERE PlanName = :planName";
                    OracleCommand checkCmd = new OracleCommand(checkPlanQuery, conn);
                    checkCmd.Parameters.Add("planName", cmbPlan.Text);

                    object result = checkCmd.ExecuteScalar();
                    int planId;

                    if (result != null)
                    {
                        // Safely convert result to int
                        planId = Convert.ToInt32(decimal.Parse(result.ToString()));
                    }
                    else
                    {
                        // 2. Insert the new plan
                        string insertPlanQuery = "INSERT INTO Plans (PlanID, PlanName) VALUES (PLANS_SEQ.NEXTVAL, :planName) RETURNING PlanID INTO :newPlanID";
                        OracleCommand insertCmd = new OracleCommand(insertPlanQuery, conn);
                        insertCmd.Parameters.Add("planName", cmbPlan.Text);
                        OracleParameter newIdParam = new OracleParameter("newPlanID", OracleDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output
                        };
                        insertCmd.Parameters.Add(newIdParam);
                        insertCmd.ExecuteNonQuery();

                        // Safely convert output to int
                        planId = Convert.ToInt32(decimal.Parse(newIdParam.Value.ToString()));
                    }

                    // 3. Insert the member
                    string insertMemberQuery = @"INSERT INTO Members 
                    (MemberID, Name, Contact, Address, Age, Gender, PlanID) 
                    VALUES (MEMBER_SEQ.NEXTVAL, :name, :contact, :address, :age, :gender, :planid)";

                    OracleCommand memberCmd = new OracleCommand(insertMemberQuery, conn);
                    memberCmd.Parameters.Add("name", txtName.Text);
                    memberCmd.Parameters.Add("contact", txtContact.Text);
                    memberCmd.Parameters.Add("address", txtAddress.Text);
                    memberCmd.Parameters.Add("age", Convert.ToInt32(numAge.Value));
                    memberCmd.Parameters.Add("gender", cmbGender.SelectedItem.ToString());
                    memberCmd.Parameters.Add("planid", planId);

                    memberCmd.ExecuteNonQuery();

                    MessageBox.Show("Member and Plan saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    manageForm?.LoadMembers();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (this.Owner != null)
            {
                this.Owner.Show();
                this.Hide();
            }
        }
    }
}
