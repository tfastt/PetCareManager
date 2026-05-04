namespace ManageForm
{
    partial class NotificationForm
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
            this.lblCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabNotif = new System.Windows.Forms.TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.tabVaccine = new System.Windows.Forms.TabPage();
            this.pnlVaccine = new System.Windows.Forms.Panel();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.pnlAll = new System.Windows.Forms.Panel();
            this.pnlAdmin = new System.Windows.Forms.Panel();
            this.tabNotif.SuspendLayout();
            this.tabVaccine.SuspendLayout();
            this.pnlAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(107, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông báo";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(93, 13);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 16);
            this.lblCount.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(666, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 41);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // tabNotif
            // 
            this.tabNotif.Controls.Add(this.tabAll);
            this.tabNotif.Controls.Add(this.tabVaccine);
            this.tabNotif.Controls.Add(this.tabAdmin);
            this.tabNotif.Location = new System.Drawing.Point(17, 46);
            this.tabNotif.Name = "tabNotif";
            this.tabNotif.SelectedIndex = 0;
            this.tabNotif.Size = new System.Drawing.Size(775, 410);
            this.tabNotif.TabIndex = 3;
            // 
            // tabAll
            // 
            this.tabAll.AutoScroll = true;
            this.tabAll.Location = new System.Drawing.Point(4, 25);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(767, 381);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "Tất cả";
            this.tabAll.UseVisualStyleBackColor = true;
            // 
            // tabVaccine
            // 
            this.tabVaccine.AutoScroll = true;
            this.tabVaccine.Controls.Add(this.pnlVaccine);
            this.tabVaccine.Location = new System.Drawing.Point(4, 25);
            this.tabVaccine.Name = "tabVaccine";
            this.tabVaccine.Padding = new System.Windows.Forms.Padding(3);
            this.tabVaccine.Size = new System.Drawing.Size(767, 381);
            this.tabVaccine.TabIndex = 1;
            this.tabVaccine.Text = "Lịch tiêm";
            this.tabVaccine.UseVisualStyleBackColor = true;
            // 
            // pnlVaccine
            // 
            this.pnlVaccine.AutoScroll = true;
            this.pnlVaccine.Location = new System.Drawing.Point(0, 0);
            this.pnlVaccine.Name = "pnlVaccine";
            this.pnlVaccine.Size = new System.Drawing.Size(766, 376);
            this.pnlVaccine.TabIndex = 0;
            // 
            // tabAdmin
            // 
            this.tabAdmin.AutoScroll = true;
            this.tabAdmin.Location = new System.Drawing.Point(4, 25);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdmin.Size = new System.Drawing.Size(767, 381);
            this.tabAdmin.TabIndex = 2;
            this.tabAdmin.Text = "Từ Admin";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // pnlAll
            // 
            this.pnlAll.AutoScroll = true;
            this.pnlAll.Controls.Add(this.pnlAdmin);
            this.pnlAll.Location = new System.Drawing.Point(17, 71);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(764, 385);
            this.pnlAll.TabIndex = 0;
            // 
            // pnlAdmin
            // 
            this.pnlAdmin.Location = new System.Drawing.Point(3, 3);
            this.pnlAdmin.Name = "pnlAdmin";
            this.pnlAdmin.Size = new System.Drawing.Size(764, 367);
            this.pnlAdmin.TabIndex = 0;
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabNotif);
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblTitle);
            this.Name = "NotificationForm";
            this.Text = "NotificationForm";
            this.tabNotif.ResumeLayout(false);
            this.tabVaccine.ResumeLayout(false);
            this.pnlAll.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabNotif;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.TabPage tabVaccine;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.Panel pnlVaccine;
        private System.Windows.Forms.Panel pnlAll;
        private System.Windows.Forms.Panel pnlAdmin;
    }
}