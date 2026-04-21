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
            this.SuspendLayout();
            // 
            // managepetsbutton
            // 
            this.managepetsbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managepetsbutton.Location = new System.Drawing.Point(161, 80);
            this.managepetsbutton.Name = "managepetsbutton";
            this.managepetsbutton.Size = new System.Drawing.Size(491, 115);
            this.managepetsbutton.TabIndex = 0;
            this.managepetsbutton.Text = "Manage Pets";
            this.managepetsbutton.UseVisualStyleBackColor = true;
            this.managepetsbutton.Click += new System.EventHandler(this.managepetsbutton_Click);
            // 
            // managevaccinesbutton
            // 
            this.managevaccinesbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managevaccinesbutton.Location = new System.Drawing.Point(161, 237);
            this.managevaccinesbutton.Name = "managevaccinesbutton";
            this.managevaccinesbutton.Size = new System.Drawing.Size(491, 115);
            this.managevaccinesbutton.TabIndex = 1;
            this.managevaccinesbutton.Text = "Manage Vaccines";
            this.managevaccinesbutton.UseVisualStyleBackColor = true;
            this.managevaccinesbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.managevaccinesbutton);
            this.Controls.Add(this.managepetsbutton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button managepetsbutton;
        private System.Windows.Forms.Button managevaccinesbutton;
    }
}

