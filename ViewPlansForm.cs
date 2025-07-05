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
    public partial class ViewPlansForm : Form
    {
        private string currentRole;
        public ViewPlansForm(string currentRole)
        {
            InitializeComponent();
            this.currentRole = currentRole;
            LoadPlans();
        }
       
        private void ViewPlansForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadPlans()
        {
            // Connect to your Oracle DB
            // Example: show plans in a DataGridView
            using (OracleConnection con = new OracleConnection("User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;"))
            {
                con.Open();
                string query = "SELECT * FROM Plans";
                OracleDataAdapter adapter = new OracleDataAdapter(query, con);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridViewPlans.DataSource = table;
            }
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
