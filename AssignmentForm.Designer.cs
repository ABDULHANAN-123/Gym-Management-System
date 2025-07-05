namespace GYM_MANAGEMENT_SYSTEM
{
    partial class AssignmentForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAssignPlan = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClear2 = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.dgvAssignments = new System.Windows.Forms.DataGridView();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbMemberID = new System.Windows.Forms.ComboBox();
            this.cmbTrainerID = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "MemberID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "MemberName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Plan:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "StartDate:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(335, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Sort By";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(335, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Assignment History:";
            // 
            // btnAssignPlan
            // 
            this.btnAssignPlan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAssignPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignPlan.ForeColor = System.Drawing.Color.Transparent;
            this.btnAssignPlan.Location = new System.Drawing.Point(19, 319);
            this.btnAssignPlan.Name = "btnAssignPlan";
            this.btnAssignPlan.Size = new System.Drawing.Size(88, 23);
            this.btnAssignPlan.TabIndex = 7;
            this.btnAssignPlan.Text = "Assign Plan";
            this.btnAssignPlan.UseVisualStyleBackColor = false;
            this.btnAssignPlan.Click += new System.EventHandler(this.btnAssignPlan_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Transparent;
            this.btnClear.Location = new System.Drawing.Point(229, 319);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClear2
            // 
            this.btnClear2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClear2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear2.ForeColor = System.Drawing.Color.Transparent;
            this.btnClear2.Location = new System.Drawing.Point(482, 108);
            this.btnClear2.Name = "btnClear2";
            this.btnClear2.Size = new System.Drawing.Size(75, 23);
            this.btnClear2.TabIndex = 11;
            this.btnClear2.Text = "Clear";
            this.btnClear2.UseVisualStyleBackColor = false;
            this.btnClear2.Click += new System.EventHandler(this.btnClear2_Click);
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSort.ForeColor = System.Drawing.Color.Transparent;
            this.btnSort.Location = new System.Drawing.Point(381, 108);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 12;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // dgvAssignments
            // 
            this.dgvAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignments.Location = new System.Drawing.Point(338, 159);
            this.dgvAssignments.Name = "dgvAssignments";
            this.dgvAssignments.Size = new System.Drawing.Size(422, 183);
            this.dgvAssignments.TabIndex = 13;
            this.dgvAssignments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssignments_CellContentClick);
            // 
            // txtMemberName
            // 
            this.txtMemberName.Location = new System.Drawing.Point(107, 150);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(100, 20);
            this.txtMemberName.TabIndex = 15;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(107, 270);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(197, 20);
            this.dtpStartDate.TabIndex = 16;
            // 
            // cmbPlan
            // 
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(107, 191);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(100, 21);
            this.cmbPlan.TabIndex = 17;
            // 
            // cmbSortBy
            // 
            this.cmbSortBy.FormattingEnabled = true;
            this.cmbSortBy.Location = new System.Drawing.Point(381, 81);
            this.cmbSortBy.Name = "cmbSortBy";
            this.cmbSortBy.Size = new System.Drawing.Size(176, 21);
            this.cmbSortBy.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(254, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 44);
            this.label8.TabIndex = 20;
            this.label8.Text = "ASSIGNMENT";
            // 
            // cmbMemberID
            // 
            this.cmbMemberID.FormattingEnabled = true;
            this.cmbMemberID.Location = new System.Drawing.Point(107, 108);
            this.cmbMemberID.Name = "cmbMemberID";
            this.cmbMemberID.Size = new System.Drawing.Size(100, 21);
            this.cmbMemberID.TabIndex = 21;
            this.cmbMemberID.SelectedIndexChanged += new System.EventHandler(this.cmbMemberID_SelectedIndexChanged_1);
            // 
            // cmbTrainerID
            // 
            this.cmbTrainerID.FormattingEnabled = true;
            this.cmbTrainerID.Location = new System.Drawing.Point(107, 231);
            this.cmbTrainerID.Name = "cmbTrainerID";
            this.cmbTrainerID.Size = new System.Drawing.Size(100, 21);
            this.cmbTrainerID.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Trainer ID:";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Blue;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Transparent;
            this.btnBack.Location = new System.Drawing.Point(12, 402);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(88, 23);
            this.btnBack.TabIndex = 24;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // AssignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.cmbTrainerID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbMemberID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbSortBy);
            this.Controls.Add(this.cmbPlan);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.txtMemberName);
            this.Controls.Add(this.dgvAssignments);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnClear2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAssignPlan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AssignmentForm";
            this.Text = "AssignmentForm";
            this.Load += new System.EventHandler(this.AssignmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAssignPlan;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClear2;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.DataGridView dgvAssignments;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.ComboBox cmbSortBy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbMemberID;
        private System.Windows.Forms.ComboBox cmbTrainerID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBack;
    }
}