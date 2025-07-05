namespace GYM_MANAGEMENT_SYSTEM
{
    partial class TrainerManagementForm
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
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvTrainers = new System.Windows.Forms.DataGridView();
            this.btnAddTrainers = new System.Windows.Forms.Button();
            this.btnEditTrainers = new System.Windows.Forms.Button();
            this.btnDeleteTrainers = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FilterTrainer";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(190, 85);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 20);
            this.txtFilter.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Red;
            this.btnSearch.Location = new System.Drawing.Point(297, 85);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.TabIndexChanged += new System.EventHandler(this.btnAddTrainers_Click);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // dgvTrainers
            // 
            this.dgvTrainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainers.Location = new System.Drawing.Point(112, 111);
            this.dgvTrainers.Name = "dgvTrainers";
            this.dgvTrainers.Size = new System.Drawing.Size(495, 214);
            this.dgvTrainers.TabIndex = 3;
            this.dgvTrainers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrainers_CellContentClick);
            // 
            // btnAddTrainers
            // 
            this.btnAddTrainers.BackColor = System.Drawing.Color.Green;
            this.btnAddTrainers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTrainers.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAddTrainers.Location = new System.Drawing.Point(112, 331);
            this.btnAddTrainers.Name = "btnAddTrainers";
            this.btnAddTrainers.Size = new System.Drawing.Size(95, 23);
            this.btnAddTrainers.TabIndex = 4;
            this.btnAddTrainers.Text = "Add Trainer";
            this.btnAddTrainers.UseVisualStyleBackColor = false;
            this.btnAddTrainers.Click += new System.EventHandler(this.btnAddTrainers_Click);
            // 
            // btnEditTrainers
            // 
            this.btnEditTrainers.BackColor = System.Drawing.Color.Crimson;
            this.btnEditTrainers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditTrainers.ForeColor = System.Drawing.SystemColors.Info;
            this.btnEditTrainers.Location = new System.Drawing.Point(310, 331);
            this.btnEditTrainers.Name = "btnEditTrainers";
            this.btnEditTrainers.Size = new System.Drawing.Size(95, 23);
            this.btnEditTrainers.TabIndex = 5;
            this.btnEditTrainers.Text = "Edit Trainer";
            this.btnEditTrainers.UseVisualStyleBackColor = false;
            this.btnEditTrainers.Click += new System.EventHandler(this.btnEditTrainers_Click);
            // 
            // btnDeleteTrainers
            // 
            this.btnDeleteTrainers.BackColor = System.Drawing.Color.Red;
            this.btnDeleteTrainers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTrainers.ForeColor = System.Drawing.SystemColors.Info;
            this.btnDeleteTrainers.Location = new System.Drawing.Point(501, 331);
            this.btnDeleteTrainers.Name = "btnDeleteTrainers";
            this.btnDeleteTrainers.Size = new System.Drawing.Size(106, 23);
            this.btnDeleteTrainers.TabIndex = 6;
            this.btnDeleteTrainers.Text = "Delete Trainer";
            this.btnDeleteTrainers.UseVisualStyleBackColor = false;
            this.btnDeleteTrainers.Click += new System.EventHandler(this.btnDeleteTrainers_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkBlue;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.Info;
            this.btnBack.Location = new System.Drawing.Point(12, 415);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // TrainerManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDeleteTrainers);
            this.Controls.Add(this.btnEditTrainers);
            this.Controls.Add(this.btnAddTrainers);
            this.Controls.Add(this.dgvTrainers);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label1);
            this.Name = "TrainerManagementForm";
            this.Text = "TrainerManagementForm";
            this.Load += new System.EventHandler(this.TrainerManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvTrainers;
        private System.Windows.Forms.Button btnAddTrainers;
        private System.Windows.Forms.Button btnEditTrainers;
        private System.Windows.Forms.Button btnDeleteTrainers;
        private System.Windows.Forms.Button btnBack;
    }
}