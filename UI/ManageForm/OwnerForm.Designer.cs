namespace ManageForm
{
    partial class OwnerForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSysInfo = new System.Windows.Forms.Button();
            this.pnlPets = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(104, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thú cưng của tôi";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnSysInfo);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 50);
            this.panel1.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(642, 9);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(130, 33);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSysInfo
            // 
            this.btnSysInfo.Location = new System.Drawing.Point(403, 9);
            this.btnSysInfo.Name = "btnSysInfo";
            this.btnSysInfo.Size = new System.Drawing.Size(130, 33);
            this.btnSysInfo.TabIndex = 1;
            this.btnSysInfo.Text = "Xem System Info";
            this.btnSysInfo.UseVisualStyleBackColor = true;
            // 
            // pnlPets
            // 
            this.pnlPets.Location = new System.Drawing.Point(13, 70);
            this.pnlPets.Name = "pnlPets";
            this.pnlPets.Size = new System.Drawing.Size(775, 368);
            this.pnlPets.TabIndex = 2;
            // 
            // OwnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlPets);
            this.Controls.Add(this.panel1);
            this.Name = "OwnerForm";
            this.Text = "OwnerForm";
            this.Load += new System.EventHandler(this.OwnerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSysInfo;
        private System.Windows.Forms.Panel pnlPets;
    }
}