namespace ManageForm
{
    partial class Form1
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
            this.managepetsbutton = new System.Windows.Forms.Button();
            this.managevaccinesbutton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // managepetsbutton
            // 
            this.managepetsbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managepetsbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managepetsbutton.Location = new System.Drawing.Point(3, 3);
            this.managepetsbutton.Name = "managepetsbutton";
            this.managepetsbutton.Size = new System.Drawing.Size(714, 179);
            this.managepetsbutton.TabIndex = 0;
            this.managepetsbutton.Text = "Manage Pets";
            this.managepetsbutton.UseVisualStyleBackColor = true;
            this.managepetsbutton.Click += new System.EventHandler(this.managepetsbutton_Click);
            // 
            // managevaccinesbutton
            // 
            this.managevaccinesbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managevaccinesbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managevaccinesbutton.Location = new System.Drawing.Point(3, 188);
            this.managevaccinesbutton.Name = "managevaccinesbutton";
            this.managevaccinesbutton.Size = new System.Drawing.Size(714, 179);
            this.managevaccinesbutton.TabIndex = 1;
            this.managevaccinesbutton.Text = "Manage Vaccines";
            this.managevaccinesbutton.UseVisualStyleBackColor = true;
            this.managevaccinesbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.managepetsbutton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.managevaccinesbutton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(40, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(720, 370);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(40);
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button managepetsbutton;
        private System.Windows.Forms.Button managevaccinesbutton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

