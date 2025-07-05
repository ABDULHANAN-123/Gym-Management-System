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
    public partial class MainMenu : Form
    {
        string ConnectionString = "User Id=GYM MANAGEMENT SYSTEM;Password=1234;Data Source=localhost:1521/xe;";
        public string currentUserRole;
        public MainMenu(string role)
        {
            InitializeComponent();
            currentUserRole = role;
        }
        private void ApplyRolePermissions()
        {

            // Hide all buttons by default
            HideAllButtons();

            switch (currentUserRole.ToLower())
            {
                case "admin":
                    // Admin has access to all buttons
                    ShowAdminButtons();
                    break;

                case "trainer":
                    // Trainers can manage assignments and attendance
                    ShowTrainerButtons();
                    break;

                case "trainee":
                    // Trainees can only view their attendance and payment
                    ShowTraineeButtons();
                    break;

                case "receptionist":
                    // Receptionist can manage member details and payments
                    ShowReceptionistButtons();
                    break;

                case "accountant":
                    // Accountant can manage payments
                    ShowAccountantButtons();
                    break;

                case "manager":
                    // Manager has broader access
                    ShowManagerButtons();
                    break;

                default:
                    // Fallback for unknown roles
                    MessageBox.Show("Unauthorized access detected!");
                    this.Close();
                    break;
            }
        }
        private void HideAllButtons()
        {
            btnMemberManagement.Visible = false;
            btnAssignments.Visible = false;
            btnTrainerManagement.Visible = false;
            btnPayments.Visible = false;
            btnPlanManagement.Visible = false;
            btnAttendance.Visible = false;
            btnSettings.Visible = false;
            btnReports.Visible = false;
        }

        private void ShowAdminButtons()
        {
            btnMemberManagement.Visible = true;
            btnAssignments.Visible = true;
            btnTrainerManagement.Visible = true;
            btnPayments.Visible = true;
            btnPlanManagement.Visible = true;
            btnAttendance.Visible = true;
            btnSettings.Visible = true;
            btnReports.Visible = true;
        }

        private void ShowTrainerButtons()
        {
            btnAssignments.Visible = true;
            btnAttendance.Visible = true;
        }

        private void ShowTraineeButtons()
        {
            btnPayments.Visible = false;
            btnViewAttendance.Visible = true; // Assuming trainees can view their attendance
            
        }

        private void ShowReceptionistButtons()
        {
            btnMemberManagement.Visible = true;
            btnPayments.Visible = true;
        }

        private void ShowAccountantButtons()
        {
            btnPayments.Visible = true; // Accountants manage payments
        }

        private void ShowManagerButtons()
        {
            btnMemberManagement.Visible = true;
            btnPayments.Visible = true;
            btnReports.Visible = true;
            btnPlanManagement.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MemberManagementForm memberForm = new MemberManagementForm(currentUserRole);
            memberForm.Owner = this;
            memberForm.Show();
            this.Hide();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInForm loginForm = new LogInForm();
            loginForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TrainerManagementForm trainerForm = new TrainerManagementForm(currentUserRole);
            trainerForm.Owner = this;
            trainerForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlanManagementForm planForm = new PlanManagementForm();
            planForm.Owner = this;
            planForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AssignmentForm assignmentForm = new AssignmentForm();
            assignmentForm.Owner = this;
            assignmentForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm(currentUserRole);
            paymentForm.Owner = this;
            paymentForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AttendanceForm attendanceForm = new AttendanceForm();
            attendanceForm.Owner = this;
            attendanceForm.Show();
            this.Hide();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            ApplyRolePermissions();
        }
       
        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                LogInForm login = new LogInForm();
                login.Show();
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Owner = this;
            reports.Show();
            this.Hide();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Owner = this;
            settings.Show();
            this.Hide();
        }

        private void btnViewPlans_Click(object sender, EventArgs e)
        {
            ViewPlansForm viewPlans = new ViewPlansForm(currentUserRole);
            viewPlans.Owner = this;
            viewPlans.Show(); 
        }

        private void btnViewAttendance_Click(object sender, EventArgs e)
        {
            ViewAttendanceForm viewAttendance = new ViewAttendanceForm(currentUserRole);
            viewAttendance.Owner = this;
            viewAttendance.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LogInForm logInForm = new LogInForm();
            logInForm.Show();
            this.Hide();
        }
    }
}
