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
    public partial class Reports : Form
    {
        OracleConnection con = new OracleConnection("User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;");
        private string currentRole;
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            cmbReportType.Items.AddRange(new string[]
           {
                "Member List",
                "Plan Assignments",
                "Payment History"
           });
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Declare the query string
            string query = "";

            // Define the query based on the selected report type
            switch (cmbReportType.Text)
            {
                case "Member List":
                    query = "SELECT * FROM Members";
                    break;
                case "Plan Assignments":
                    query = @"SELECT A.AssignmentID, M.Name, P.PlanName, A.StartDate 
                      FROM Assignments A 
                      JOIN Members M ON A.MemberID = M.MemberID 
                      JOIN Plans P ON A.PlanID = P.PlanID";
                    break;
                case "Payment History":
                    query = @"SELECT P.PaymentID, M.Name, PL.PlanName, P.Amount, P.PaymentDate 
                      FROM Payments P 
                      JOIN Members M ON P.MemberID = M.MemberID 
                      JOIN Plans PL ON P.PlanID = PL.PlanID";
                    break;
                default:
                    MessageBox.Show("Please select a valid report type.");
                    return;
            }

            try
            {
                // Ensure you have an active connection (replace 'connectionString' with your actual connection string)
                using (OracleConnection con = new OracleConnection("User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;"))
                {
                    con.Open(); // Open the connection

                    // Initialize OracleDataAdapter to fill the DataTable
                    OracleDataAdapter da = new OracleDataAdapter(query, con);
                    DataTable dt = new DataTable();

                    // Fill the DataTable with the result of the query
                    da.Fill(dt);

                    // Check if the DataTable has rows
                    if (dt.Rows.Count > 0)
                    {
                        // Bind the DataTable to the DataGridView
                        dgvReport.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No data found for the selected report.");
                    }
                }
            }
            catch (OracleException ex)
            {
                // Handle specific Oracle exceptions
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Catch any other exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (dgvReport.DataSource == null)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV|*.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var dt = (DataTable)dgvReport.DataSource;
                var lines = new List<string>();

                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(col => col.ColumnName).ToArray();
                lines.Add(string.Join(",", columnNames));

                foreach (DataRow row in dt.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    lines.Add(string.Join(",", fields));
                }

                System.IO.File.WriteAllLines(sfd.FileName, lines);
                MessageBox.Show("Exported successfully!");
            }
        }

        private void dgvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
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
