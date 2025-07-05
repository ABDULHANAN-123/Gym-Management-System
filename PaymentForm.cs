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
    public partial class PaymentForm : Form
    {
        string connectionString = "User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;";
        private string currentRole;
        public PaymentForm(string role)
        {
            InitializeComponent();
            LoadMemberIDs();
            LoadPaymentHistory();
            InitializeComboBoxes();
            planDatePicker.Value = DateTime.Today;
            this.currentRole = role;
        }
        private void InitializeComboBoxes()
        {
            // Add payment method options
            paymentMethodComboBox.Items.Clear();
            paymentMethodComboBox.Items.AddRange(new string[] { "Cash", "Credit Card", "Debit Card", "UPI", "Bank Transfer" });

            // Add status options
            paymentStatusComboBox.Items.Clear();
            paymentStatusComboBox.Items.AddRange(new string[] { "Paid", "Pending", "Failed" });
        }
        private void LoadMemberIDs()
        {
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("SELECT MemberID FROM Members", con);
                OracleDataReader reader = cmd.ExecuteReader();
                memberIDComboBox.Items.Clear();
                while (reader.Read())
                {
                    memberIDComboBox.Items.Add(reader["MemberID"].ToString());
                }
            }
        }
        private void memberIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(@"
                    SELECT M.Name, M.Contact, P.PlanName 
                    FROM Members M 
                    LEFT JOIN Plans P ON M.PlanID = P.PlanID 
                    WHERE M.MemberID = :memberID", con);

                cmd.Parameters.Add(new OracleParameter("memberID", memberIDComboBox.Text));
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    memberNameTextBox.Text = reader["Name"]?.ToString() ?? "";
                    contactNumberTextBox.Text = reader["Contact"]?.ToString() ?? "";
                    membershipPlanComboBox.Text = reader["PlanName"]?.ToString() ?? "";
                }
            }
        }
        private void addPaymentButton_Click(object sender, EventArgs e)
        {
           
        }


        private void LoadPaymentHistory()
        {
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                con.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(@"
            SELECT P.PaymentID, P.MemberID, M.Name AS MemberName, 
                   P.Amount, P.Method, P.TransactionID, P.Status, P.PaymentDate
            FROM Payments P
            JOIN Members M ON P.MemberID = M.MemberID
            ORDER BY P.PaymentDate DESC", con);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                paymentHistoryDataGridView.DataSource = dt;
            }
        }


        private void ClearFields()
        {
            memberIDComboBox.SelectedIndex = -1;
            memberNameTextBox.Clear();
            contactNumberTextBox.Clear();
            membershipPlanComboBox.SelectedIndex = -1;
            planDatePicker.Value = DateTime.Today;
            amountTextBox.Clear();
            paymentMethodComboBox.SelectedIndex = -1;
            transactionIDTextBox.Clear();
            paymentStatusComboBox.SelectedIndex = -1;
        }


        private void clearButton_Click(object sender, EventArgs e)
        {
            
        }


        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadPaymentHistory();
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            
            LoadPaymentHistory();
        }

        private void memberIDComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadMemberDetailsByID();
                e.SuppressKeyPress = true; // Prevents beep sound on Enter
            }
        }
        private void LoadMemberDetailsByID()
        {
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(@"
            SELECT M.Name, M.Contact, P.PlanName 
            FROM Members M 
            LEFT JOIN Plans P ON M.PlanID = P.PlanID 
            WHERE M.MemberID = :memberID", con);

                cmd.Parameters.Add(new OracleParameter("memberID", memberIDComboBox.Text));
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    memberNameTextBox.Text = reader["Name"]?.ToString() ?? "";
                    contactNumberTextBox.Text = reader["Contact"]?.ToString() ?? "";
                    membershipPlanComboBox.Text = reader["PlanName"]?.ToString() ?? "";
                }
                else
                {
                    MessageBox.Show("No member found with the entered ID.");
                }
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand(@"
                INSERT INTO Payments 
                (PaymentID, MemberID, Amount, PaymentDate, Method, TransactionID, Status) 
                VALUES 
                (PAYMENTS_SEQ.NEXTVAL, :memberID, :amount, :paymentDate, :method, :transactionID, :status)", con);

                    cmd.Parameters.Add("memberID", memberIDComboBox.Text);
                    cmd.Parameters.Add("amount", Convert.ToDecimal(amountTextBox.Text));
                    cmd.Parameters.Add("paymentDate", planDatePicker.Value);
                    cmd.Parameters.Add("method", paymentMethodComboBox.Text);
                    cmd.Parameters.Add("transactionID", transactionIDTextBox.Text);
                    cmd.Parameters.Add("status", paymentStatusComboBox.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Payment recorded successfully.");
                        LoadPaymentHistory();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Payment was not recorded.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
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
