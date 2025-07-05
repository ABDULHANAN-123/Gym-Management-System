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
    public partial class AttendanceForm : Form
    {
        OracleConnection con = new OracleConnection("User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;");
        private string currentRole;
        public AttendanceForm()
        {
            InitializeComponent();
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            cmbMemberID.KeyDown += cmbMemberID_KeyDown;
            LoadMemberIDs();
            cmbAttendanceStatus.Items.AddRange(new string[] { "Present", "Absent" });
            cmbSortBy.Items.AddRange(new string[]
{
    "Member ID",
    "Member Name",
    "Attendance Date (Newest First)",
    "Attendance Date (Oldest First)",
    "Attendance Status",
    "Attendance ID"
});

            dtpAttendanceDate.Value = DateTime.Today;
            LoadAttendanceHistory();
        }
        private void cmbMemberID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadMemberName();
            }
        }
        private void LoadMemberName()
        {
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("SELECT Name FROM Members WHERE MemberID = :id", con);
                cmd.Parameters.Add(new OracleParameter("id", cmbMemberID.Text));
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtMemberName.Text = dr["Name"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading member name: " + ex.Message);
            }
        }

        private void LoadMemberIDs()
        {
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("SELECT MemberID FROM Members", con);
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbMemberID.Items.Add(dr[0].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Member IDs: " + ex.Message);
            }
        }

        private void cmbMemberID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMemberName();
        }

        private void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            if (cmbMemberID.Text == "" || cmbAttendanceStatus.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO Attendance (AttendanceID, MemberID, AttendanceDate, Status) VALUES (ATTENDANCE_SEQ.NEXTVAL, :memberID, :date, :status)", con);
                cmd.Parameters.Add("memberID", cmbMemberID.Text);
                cmd.Parameters.Add("date", dtpAttendanceDate.Value);
                cmd.Parameters.Add("status", cmbAttendanceStatus.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Attendance marked successfully!");
                LoadAttendanceHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error marking attendance: " + ex.Message);
            }
        }

        private void LoadAttendanceHistory(string filterColumn = "", string filterValue = "")
        {
            try
            {
                con.Open();
                string query = "SELECT A.AttendanceID, A.MemberID, M.Name, A.AttendanceDate, A.Status FROM Attendance A JOIN Members M ON A.MemberID = M.MemberID";
                if (!string.IsNullOrEmpty(filterColumn))
                {
                    query += $" WHERE A.{filterColumn} = :val ORDER BY A.AttendanceDate DESC";
                }
                OracleCommand cmd = new OracleCommand(query, con);
                if (!string.IsNullOrEmpty(filterColumn))
                    cmd.Parameters.Add(new OracleParameter("val", filterValue));

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAttendance.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance history: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbSortBy.Text == "Date")
            {
                LoadAttendanceHistory("AttendanceDate", dtpAttendanceDate.Value.ToString("dd-MMM-yyyy"));
            }
            else if (cmbSortBy.Text == "Status")
            {
                LoadAttendanceHistory("Status", cmbAttendanceStatus.Text);
            }
            else
            {
                MessageBox.Show("Please select a valid Sort By filter.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbMemberID.SelectedIndex = -1;
            txtMemberName.Clear();
            cmbAttendanceStatus.SelectedIndex = -1;
            cmbSortBy.SelectedIndex = -1;
            dtpAttendanceDate.Value = DateTime.Today;
            dgvAttendance.DataSource = null;
        }

        private void cmbMemberID_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadMemberName();
                e.SuppressKeyPress = true; // Prevent ding sound
            }
        }

        private void btnMarkAttendance_Click_1(object sender, EventArgs e)
        {
            if (cmbMemberID.Text == "" || cmbAttendanceStatus.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            
            try
            {

                con.Open();
                string query = "INSERT INTO Attendance (AttendanceID, MemberID, AttendanceDate, Status) VALUES (ATTENDANCE_SEQ.NEXTVAL, :MemberID, :AttendanceDate, :Status)";
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.Parameters.Add(":MemberID", OracleDbType.Int32).Value = Convert.ToInt32(cmbMemberID.Text);
                cmd.Parameters.Add(":AttendanceDate", OracleDbType.Date).Value = dtpAttendanceDate.Value;
                cmd.Parameters.Add(":Status", OracleDbType.Varchar2).Value = cmbAttendanceStatus.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Attendance marked successfully!");
                LoadAttendanceHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error marking attendance: " + ex.Message);
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string orderByClause = "A.AttendanceDate DESC"; // default

            switch (cmbSortBy.Text)
            {
                case "Attendance ID":
                    orderByClause = "A.AttendanceID";
                    break;
                case "Member ID":
                    orderByClause = "A.MemberID";
                    break;
                case "Member Name":
                    orderByClause = "M.Name";
                    break;
                case "Attendance Date (Newest First)":
                    orderByClause = "A.AttendanceDate DESC";
                    break;
                case "Attendance Date (Oldest First)":
                    orderByClause = "A.AttendanceDate ASC";
                    break;
                case "Attendance Status":
                    orderByClause = "A.Status";
                    break;
                default:
                    MessageBox.Show("Please select a valid 'Sort By' option.");
                    return;
            }

            LoadAttendanceHistoryWithSort(orderByClause);
        }
        private void LoadAttendanceHistoryWithSort(string orderBy)
        {
            try
            {
                con.Open();
                string query = "SELECT A.AttendanceID, A.MemberID, M.Name, A.AttendanceDate, A.Status " +
                               "FROM Attendance A " +
                               "JOIN Members M ON A.MemberID = M.MemberID " +
                               $"ORDER BY {orderBy}";

                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAttendance.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance history: " + ex.Message);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            cmbMemberID.SelectedIndex = -1;
            txtMemberName.Clear();
            cmbAttendanceStatus.SelectedIndex = -1;
            cmbSortBy.SelectedIndex = -1;
            dtpAttendanceDate.Value = DateTime.Today;
            dgvAttendance.DataSource = null;
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
