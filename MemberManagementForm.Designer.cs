namespace GYM_MANAGEMENT_SYSTEM
{
    partial class MemberManagementForm
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
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.btnEditMember = new System.Windows.Forms.Button();
            this.btnDeleteMember = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Backbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMembers
            // 
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Location = new System.Drawing.Point(109, 85);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.Size = new System.Drawing.Size(550, 271);
            this.dgvMembers.TabIndex = 0;
            // 
            // btnAddMember
            // 
            this.btnAddMember.BackColor = System.Drawing.Color.Lime;
            this.btnAddMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMember.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddMember.Location = new System.Drawing.Point(109, 379);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(102, 35);
            this.btnAddMember.TabIndex = 1;
            this.btnAddMember.Text = "Add Member";
            this.btnAddMember.UseVisualStyleBackColor = false;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click_1);
            // 
            // btnEditMember
            // 
            this.btnEditMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEditMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditMember.ForeColor = System.Drawing.Color.Transparent;
            this.btnEditMember.Location = new System.Drawing.Point(328, 379);
            this.btnEditMember.Name = "btnEditMember";
            this.btnEditMember.Size = new System.Drawing.Size(102, 35);
            this.btnEditMember.TabIndex = 2;
            this.btnEditMember.Text = "Edit Member";
            this.btnEditMember.UseVisualStyleBackColor = false;
            this.btnEditMember.Click += new System.EventHandler(this.btnEditMember_Click_1);
            // 
            // btnDeleteMember
            // 
            this.btnDeleteMember.BackColor = System.Drawing.Color.Red;
            this.btnDeleteMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMember.ForeColor = System.Drawing.Color.Transparent;
            this.btnDeleteMember.Location = new System.Drawing.Point(572, 379);
            this.btnDeleteMember.Name = "btnDeleteMember";
            this.btnDeleteMember.Size = new System.Drawing.Size(102, 35);
            this.btnDeleteMember.TabIndex = 3;
            this.btnDeleteMember.Text = "Delete Member";
            this.btnDeleteMember.UseVisualStyleBackColor = false;
            this.btnDeleteMember.Click += new System.EventHandler(this.btnDeleteMember_Click_1);
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(222, 59);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(113, 20);
            this.txtFilter.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Red;
            this.btnSearch.Location = new System.Drawing.Point(341, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 20);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "FILTER MEMBERS";
            // 
            // Backbtn
            // 
            this.Backbtn.BackColor = System.Drawing.Color.Blue;
            this.Backbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Backbtn.ForeColor = System.Drawing.Color.Transparent;
            this.Backbtn.Location = new System.Drawing.Point(713, 415);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(75, 23);
            this.Backbtn.TabIndex = 7;
            this.Backbtn.Text = "Back";
            this.Backbtn.UseVisualStyleBackColor = false;
            this.Backbtn.Click += new System.EventHandler(this.Backbtn_Click);
            // 
            // MemberManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Backbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnDeleteMember);
            this.Controls.Add(this.btnEditMember);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.dgvMembers);
            this.Name = "MemberManagementForm";
            this.Text = "MemberManagementForm";
            this.Load += new System.EventHandler(this.MemberManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.Button btnEditMember;
        private System.Windows.Forms.Button btnDeleteMember;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Backbtn;
    }
}