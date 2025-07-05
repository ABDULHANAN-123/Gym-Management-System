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
    public partial class AssignmentForm : Form
    {
        OracleConnection con = new OracleConnection("User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;");
        private string currentRole;
        public AssignmentForm()
        {
            InitializeComponent();
        }

        private void AssignmentForm_Load(object sender, EventArgs e)
        {
            LoadMemberIDs();
            LoadPlans();
            LoadTrainerIDs();
            cmbTrainerID.DropDownStyle = ComboBoxStyle.DropDownList;
            dtpStartDate.Value = DateTime.Today;

            cmbSortBy.Items.AddRange(new string[] {
                "Assignment ID",
                "Member ID",
                "Member Name",
                "Plan Name",
                "Start Date (Newest)",
                "Start Date (Oldest)"
            });

            LoadAssignments();
        }
        private void LoadMemberIDs()
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT MemberID FROM Members", con);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                cmbMemberID.Items.Add(dr[0].ToString());
            con.Close();
        }

        private void LoadPlans()
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT PlanName FROM Plans", con);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                cmbPlan.Items.Add(dr[0].ToString());
            con.Close();
        }
        private void cmbMemberID_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT Name FROM Members WHERE MemberID = :id", con);
            cmd.Parameters.Add(new OracleParameter("id", cmbMemberID.Text));
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                txtMemberName.Text = dr["Name"].ToString();
            con.Close();
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            if (cmbSortBy.SelectedItem != null)
                LoadAssignments(cmbSortBy.SelectedItem.ToString());
            else
                MessageBox.Show("Please select a sort option.");
        }

        private void btnAssignPlan_Click(object sender, EventArgs e)
        {
            if (cmbMemberID.SelectedIndex == -1 || cmbPlan.SelectedIndex == -1 || cmbTrainerID.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Member, Plan, and Trainer.");
                return;
            }

            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(@"
            INSERT INTO Assignments 
            (AssignmentID, MemberID, PlanID, TrainerID, StartDate) 
            VALUES (
                ASSIGN_SEQ.NEXTVAL, 
                :memberID, 
                (SELECT PlanID FROM Plans WHERE PlanName = :planName), 
                :trainerID, 
                :startDate)", con);

                cmd.Parameters.Add(":memberID", OracleDbType.Int32).Value = Convert.ToInt32(cmbMemberID.Text);
                cmd.Parameters.Add(":planName", OracleDbType.Varchar2).Value = cmbPlan.Text;
                cmd.Parameters.Add(":trainerID", OracleDbType.Int32).Value = Convert.ToInt32(cmbTrainerID.Text);
                cmd.Parameters.Add(":startDate", OracleDbType.Date).Value = dtpStartDate.Value;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Plan assigned successfully!");
                LoadAssignments();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void LoadTrainerIDs()
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT TrainerID FROM Trainers", con);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                cmbTrainerID.Items.Add(dr[0].ToString());
            con.Close();
        }

        private void LoadAssignments(string sortOption = "")
        {
            string query = @"SELECT A.AssignmentID, A.MemberID, M.Name AS MemberName, 
                        P.PlanName, T.NAME AS Trainer, A.StartDate 
                 FROM Assignments A 
                 JOIN Members M ON A.MemberID = M.MemberID 
                 JOIN Plans P ON A.PlanID = P.PlanID
                 JOIN Trainers T ON A.TrainerID = T.TrainerID";

            switch (sortOption)
            {
                case "Assignment ID":
                    query += " ORDER BY A.AssignmentID";
                    break;
                case "Member ID":
                    query += " ORDER BY A.MemberID";
                    break;
                case "Member Name":
                    query += " ORDER BY M.Name";
                    break;
                case "Plan Name":
                    query += " ORDER BY P.PlanName";
                    break;
                case "Start Date (Newest)":
                    query += " ORDER BY A.StartDate DESC";
                    break;
                case "Start Date (Oldest)":
                    query += " ORDER BY A.StartDate ASC";
                    break;
                case "Trainer Name":  // New sort option
                    query += " ORDER BY T.Name";
                    break;
            }

            OracleDataAdapter da = new OracleDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAssignments.DataSource = dt;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbMemberID.SelectedIndex = -1;
            txtMemberName.Clear();
            cmbPlan.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Today;
            cmbSortBy.SelectedIndex = -1;
            dgvAssignments.DataSource = null;
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            cmbMemberID.SelectedIndex = -1;
            txtMemberName.Clear();
            cmbPlan.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Today;
            cmbSortBy.SelectedIndex = -1;
            dgvAssignments.DataSource = null;
        }

        private void dgvAssignments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbMemberID_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT Name FROM Members WHERE MemberID = :id", con);
            cmd.Parameters.Add(new OracleParameter("id", cmbMemberID.Text));
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                txtMemberName.Text = dr["Name"].ToString();
            con.Close();
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
