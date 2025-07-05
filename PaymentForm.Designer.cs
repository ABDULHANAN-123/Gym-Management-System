namespace GYM_MANAGEMENT_SYSTEM
{
    partial class PaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contactNumberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.memberNameTextBox = new System.Windows.Forms.TextBox();
            this.planDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.paymentMethodComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.paymentStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.paymentHistoryDataGridView = new System.Windows.Forms.DataGridView();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.memberIDComboBox = new System.Windows.Forms.ComboBox();
            this.membershipPlanComboBox = new System.Windows.Forms.ComboBox();
            this.transactionIDTextBox = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.paymentHistoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Member ID:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Member Name:";
            // 
            // contactNumberTextBox
            // 
            this.contactNumberTextBox.Location = new System.Drawing.Point(166, 160);
            this.contactNumberTextBox.Name = "contactNumberTextBox";
            this.contactNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.contactNumberTextBox.TabIndex = 2;
            this.contactNumberTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contact Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Membership Plan:";
            // 
            // memberNameTextBox
            // 
            this.memberNameTextBox.Location = new System.Drawing.Point(166, 125);
            this.memberNameTextBox.Name = "memberNameTextBox";
            this.memberNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.memberNameTextBox.TabIndex = 6;
            // 
            // planDatePicker
            // 
            this.planDatePicker.Location = new System.Drawing.Point(166, 271);
            this.planDatePicker.Name = "planDatePicker";
            this.planDatePicker.Size = new System.Drawing.Size(200, 20);
            this.planDatePicker.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(310, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 44);
            this.label6.TabIndex = 9;
            this.label6.Text = "PAYMENTS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Mistral", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(530, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "PAYMENTS HISTORY";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Mistral", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(162, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "MEMBER SELECTION";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Mistral", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(162, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "PAYMENT DETAILS";
            // 
            // paymentMethodComboBox
            // 
            this.paymentMethodComboBox.FormattingEnabled = true;
            this.paymentMethodComboBox.Location = new System.Drawing.Point(165, 327);
            this.paymentMethodComboBox.Name = "paymentMethodComboBox";
            this.paymentMethodComboBox.Size = new System.Drawing.Size(101, 21);
            this.paymentMethodComboBox.TabIndex = 22;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(165, 297);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(100, 20);
            this.amountTextBox.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(54, 362);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Transaction ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(54, 335);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Payment Method:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(54, 304);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Amount:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(54, 277);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Plan Date:";
            // 
            // paymentStatusComboBox
            // 
            this.paymentStatusComboBox.FormattingEnabled = true;
            this.paymentStatusComboBox.Location = new System.Drawing.Point(166, 385);
            this.paymentStatusComboBox.Name = "paymentStatusComboBox";
            this.paymentStatusComboBox.Size = new System.Drawing.Size(101, 21);
            this.paymentStatusComboBox.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(54, 385);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Payment Status:";
            // 
            // paymentHistoryDataGridView
            // 
            this.paymentHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentHistoryDataGridView.Location = new System.Drawing.Point(413, 98);
            this.paymentHistoryDataGridView.Name = "paymentHistoryDataGridView";
            this.paymentHistoryDataGridView.Size = new System.Drawing.Size(353, 308);
            this.paymentHistoryDataGridView.TabIndex = 26;
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddPayment.Font = new System.Drawing.Font("Mistral", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPayment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddPayment.Location = new System.Drawing.Point(82, 418);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(96, 23);
            this.btnAddPayment.TabIndex = 27;
            this.btnAddPayment.Text = "ADD  PAYMENT";
            this.btnAddPayment.UseVisualStyleBackColor = false;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Mistral", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClear.Location = new System.Drawing.Point(291, 418);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // memberIDComboBox
            // 
            this.memberIDComboBox.FormattingEnabled = true;
            this.memberIDComboBox.Location = new System.Drawing.Point(165, 98);
            this.memberIDComboBox.Name = "memberIDComboBox";
            this.memberIDComboBox.Size = new System.Drawing.Size(102, 21);
            this.memberIDComboBox.TabIndex = 32;
            this.memberIDComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.memberIDComboBox_KeyDown);
            // 
            // membershipPlanComboBox
            // 
            this.membershipPlanComboBox.FormattingEnabled = true;
            this.membershipPlanComboBox.Location = new System.Drawing.Point(165, 192);
            this.membershipPlanComboBox.Name = "membershipPlanComboBox";
            this.membershipPlanComboBox.Size = new System.Drawing.Size(101, 21);
            this.membershipPlanComboBox.TabIndex = 33;
            // 
            // transactionIDTextBox
            // 
            this.transactionIDTextBox.Location = new System.Drawing.Point(165, 359);
            this.transactionIDTextBox.Name = "transactionIDTextBox";
            this.transactionIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.transactionIDTextBox.TabIndex = 34;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkBlue;
            this.btnBack.Font = new System.Drawing.Font("Mistral", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Transparent;
            this.btnBack.Location = new System.Drawing.Point(701, 437);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(96, 23);
            this.btnBack.TabIndex = 35;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 472);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.transactionIDTextBox);
            this.Controls.Add(this.membershipPlanComboBox);
            this.Controls.Add(this.memberIDComboBox);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.paymentHistoryDataGridView);
            this.Controls.Add(this.paymentStatusComboBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.paymentMethodComboBox);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.planDatePicker);
            this.Controls.Add(this.memberNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.contactNumberTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PaymentForm";
            this.Text = "PaymentForm";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paymentHistoryDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox contactNumberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox memberNameTextBox;
        private System.Windows.Forms.DateTimePicker planDatePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox paymentMethodComboBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox paymentStatusComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView paymentHistoryDataGridView;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox memberIDComboBox;
        private System.Windows.Forms.ComboBox membershipPlanComboBox;
        private System.Windows.Forms.TextBox transactionIDTextBox;
        private System.Windows.Forms.Button btnBack;
    }
}