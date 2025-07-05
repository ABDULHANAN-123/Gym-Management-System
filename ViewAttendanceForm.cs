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
    public partial class ViewAttendanceForm : Form
    {
        private string currentRole;
        public ViewAttendanceForm(string currentRole)
        {
            InitializeComponent();
            LoadAttendance();
            this.currentRole = currentRole;
        }
        private void LoadAttendance()
        {
            using (OracleConnection con = new OracleConnection("User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;"))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Attendance";
                    OracleDataAdapter adapter = new OracleDataAdapter(query, con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewAttendance.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading trainee attendance: " + ex.Message);
                }
            }
        }
        private void ViewAttendanceForm_Load(object sender, EventArgs e)
        {

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
