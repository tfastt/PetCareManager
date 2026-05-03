namespace ManageForm
{
    partial class ManageProForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPet = new System.Windows.Forms.TabPage();
            this.dgvPets = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchPet = new System.Windows.Forms.Button();
            this.btnDeletePet = new System.Windows.Forms.Button();
            this.btnUpdatePet = new System.Windows.Forms.Button();
            this.btnAddPet = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtOwnerName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtBreed = new System.Windows.Forms.TextBox();
            this.txtSpecies = new System.Windows.Forms.TextBox();
            this.txtPetName = new System.Windows.Forms.TextBox();
            this.txtPetID = new System.Windows.Forms.TextBox();
            this.tabVaccine = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvVaccines = new System.Windows.Forms.DataGridView();
            this.btnSearchVac = new System.Windows.Forms.Button();
            this.btnDeleteVac = new System.Windows.Forms.Button();
            this.btnUpdateVac = new System.Windows.Forms.Button();
            this.btnAddVac = new System.Windows.Forms.Button();
            this.txtVacNote = new System.Windows.Forms.TextBox();
            this.dtpNextInjectionDate = new System.Windows.Forms.DateTimePicker();
            this.dtpInjectionDate = new System.Windows.Forms.DateTimePicker();
            this.txtVaccineName = new System.Windows.Forms.TextBox();
            this.txtVacPetID = new System.Windows.Forms.TextBox();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPets)).BeginInit();
            this.tabVaccine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccines)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Pro";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPet);
            this.tabControl.Controls.Add(this.tabVaccine);
            this.tabControl.Location = new System.Drawing.Point(13, 32);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(775, 390);
            this.tabControl.TabIndex = 1;
            // 
            // tabPet
            // 
            this.tabPet.Controls.Add(this.dgvPets);
            this.tabPet.Controls.Add(this.label8);
            this.tabPet.Controls.Add(this.label7);
            this.tabPet.Controls.Add(this.label6);
            this.tabPet.Controls.Add(this.label5);
            this.tabPet.Controls.Add(this.label4);
            this.tabPet.Controls.Add(this.label3);
            this.tabPet.Controls.Add(this.label2);
            this.tabPet.Controls.Add(this.btnSearchPet);
            this.tabPet.Controls.Add(this.btnDeletePet);
            this.tabPet.Controls.Add(this.btnUpdatePet);
            this.tabPet.Controls.Add(this.btnAddPet);
            this.tabPet.Controls.Add(this.txtNote);
            this.tabPet.Controls.Add(this.txtOwnerName);
            this.tabPet.Controls.Add(this.txtAge);
            this.tabPet.Controls.Add(this.txtBreed);
            this.tabPet.Controls.Add(this.txtSpecies);
            this.tabPet.Controls.Add(this.txtPetName);
            this.tabPet.Controls.Add(this.txtPetID);
            this.tabPet.Location = new System.Drawing.Point(4, 25);
            this.tabPet.Name = "tabPet";
            this.tabPet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPet.Size = new System.Drawing.Size(767, 361);
            this.tabPet.TabIndex = 0;
            this.tabPet.Text = "Quản lý Pet";
            this.tabPet.UseVisualStyleBackColor = true;
            // 
            // dgvPets
            // 
            this.dgvPets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPets.Location = new System.Drawing.Point(7, 221);
            this.dgvPets.Name = "dgvPets";
            this.dgvPets.RowHeadersWidth = 51;
            this.dgvPets.RowTemplate.Height = 24;
            this.dgvPets.Size = new System.Drawing.Size(754, 134);
            this.dgvPets.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(408, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Note";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Owner Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Age";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(599, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Breed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Species";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Pet Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Pet ID";
            // 
            // btnSearchPet
            // 
            this.btnSearchPet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPet.Location = new System.Drawing.Point(382, 173);
            this.btnSearchPet.Name = "btnSearchPet";
            this.btnSearchPet.Size = new System.Drawing.Size(119, 41);
            this.btnSearchPet.TabIndex = 10;
            this.btnSearchPet.Text = "Search";
            this.btnSearchPet.UseVisualStyleBackColor = true;
            // 
            // btnDeletePet
            // 
            this.btnDeletePet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePet.Location = new System.Drawing.Point(257, 173);
            this.btnDeletePet.Name = "btnDeletePet";
            this.btnDeletePet.Size = new System.Drawing.Size(119, 41);
            this.btnDeletePet.TabIndex = 9;
            this.btnDeletePet.Text = "Delete";
            this.btnDeletePet.UseVisualStyleBackColor = true;
            // 
            // btnUpdatePet
            // 
            this.btnUpdatePet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePet.Location = new System.Drawing.Point(132, 173);
            this.btnUpdatePet.Name = "btnUpdatePet";
            this.btnUpdatePet.Size = new System.Drawing.Size(119, 41);
            this.btnUpdatePet.TabIndex = 8;
            this.btnUpdatePet.Text = "Update";
            this.btnUpdatePet.UseVisualStyleBackColor = true;
            // 
            // btnAddPet
            // 
            this.btnAddPet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPet.Location = new System.Drawing.Point(7, 173);
            this.btnAddPet.Name = "btnAddPet";
            this.btnAddPet.Size = new System.Drawing.Size(119, 41);
            this.btnAddPet.TabIndex = 7;
            this.btnAddPet.Text = "Add";
            this.btnAddPet.UseVisualStyleBackColor = true;
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(405, 133);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(134, 34);
            this.txtNote.TabIndex = 6;
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOwnerName.Location = new System.Drawing.Point(204, 133);
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(134, 34);
            this.txtOwnerName.TabIndex = 5;
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(23, 133);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(134, 34);
            this.txtAge.TabIndex = 4;
            // 
            // txtBreed
            // 
            this.txtBreed.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBreed.Location = new System.Drawing.Point(599, 61);
            this.txtBreed.Name = "txtBreed";
            this.txtBreed.Size = new System.Drawing.Size(134, 34);
            this.txtBreed.TabIndex = 3;
            // 
            // txtSpecies
            // 
            this.txtSpecies.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecies.Location = new System.Drawing.Point(405, 61);
            this.txtSpecies.Name = "txtSpecies";
            this.txtSpecies.Size = new System.Drawing.Size(134, 34);
            this.txtSpecies.TabIndex = 2;
            // 
            // txtPetName
            // 
            this.txtPetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPetName.Location = new System.Drawing.Point(204, 61);
            this.txtPetName.Name = "txtPetName";
            this.txtPetName.Size = new System.Drawing.Size(134, 34);
            this.txtPetName.TabIndex = 1;
            // 
            // txtPetID
            // 
            this.txtPetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPetID.Location = new System.Drawing.Point(23, 61);
            this.txtPetID.Name = "txtPetID";
            this.txtPetID.Size = new System.Drawing.Size(134, 34);
            this.txtPetID.TabIndex = 0;
            // 
            // tabVaccine
            // 
            this.tabVaccine.Controls.Add(this.label13);
            this.tabVaccine.Controls.Add(this.label12);
            this.tabVaccine.Controls.Add(this.label11);
            this.tabVaccine.Controls.Add(this.label10);
            this.tabVaccine.Controls.Add(this.label9);
            this.tabVaccine.Controls.Add(this.dgvVaccines);
            this.tabVaccine.Controls.Add(this.btnSearchVac);
            this.tabVaccine.Controls.Add(this.btnDeleteVac);
            this.tabVaccine.Controls.Add(this.btnUpdateVac);
            this.tabVaccine.Controls.Add(this.btnAddVac);
            this.tabVaccine.Controls.Add(this.txtVacNote);
            this.tabVaccine.Controls.Add(this.dtpNextInjectionDate);
            this.tabVaccine.Controls.Add(this.dtpInjectionDate);
            this.tabVaccine.Controls.Add(this.txtVaccineName);
            this.tabVaccine.Controls.Add(this.txtVacPetID);
            this.tabVaccine.Location = new System.Drawing.Point(4, 25);
            this.tabVaccine.Name = "tabVaccine";
            this.tabVaccine.Padding = new System.Windows.Forms.Padding(3);
            this.tabVaccine.Size = new System.Drawing.Size(767, 361);
            this.tabVaccine.TabIndex = 1;
            this.tabVaccine.Text = "Quản lý Vaccine";
            this.tabVaccine.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 25);
            this.label13.TabIndex = 16;
            this.label13.Text = "Note";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(385, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(175, 25);
            this.label12.TabIndex = 15;
            this.label12.Text = "Next Injection Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(382, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 25);
            this.label11.TabIndex = 14;
            this.label11.Text = "Injection Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(197, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 25);
            this.label10.TabIndex = 13;
            this.label10.Text = "Vaccine Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 25);
            this.label9.TabIndex = 12;
            this.label9.Text = "Pet ID";
            // 
            // dgvVaccines
            // 
            this.dgvVaccines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaccines.Location = new System.Drawing.Point(7, 221);
            this.dgvVaccines.Name = "dgvVaccines";
            this.dgvVaccines.RowHeadersWidth = 51;
            this.dgvVaccines.RowTemplate.Height = 24;
            this.dgvVaccines.Size = new System.Drawing.Size(754, 134);
            this.dgvVaccines.TabIndex = 11;
            // 
            // btnSearchVac
            // 
            this.btnSearchVac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchVac.Location = new System.Drawing.Point(382, 174);
            this.btnSearchVac.Name = "btnSearchVac";
            this.btnSearchVac.Size = new System.Drawing.Size(119, 41);
            this.btnSearchVac.TabIndex = 8;
            this.btnSearchVac.Text = "Search";
            this.btnSearchVac.UseVisualStyleBackColor = true;
            // 
            // btnDeleteVac
            // 
            this.btnDeleteVac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteVac.Location = new System.Drawing.Point(257, 174);
            this.btnDeleteVac.Name = "btnDeleteVac";
            this.btnDeleteVac.Size = new System.Drawing.Size(119, 41);
            this.btnDeleteVac.TabIndex = 7;
            this.btnDeleteVac.Text = "Delete";
            this.btnDeleteVac.UseVisualStyleBackColor = true;
            // 
            // btnUpdateVac
            // 
            this.btnUpdateVac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateVac.Location = new System.Drawing.Point(132, 174);
            this.btnUpdateVac.Name = "btnUpdateVac";
            this.btnUpdateVac.Size = new System.Drawing.Size(119, 41);
            this.btnUpdateVac.TabIndex = 6;
            this.btnUpdateVac.Text = "Update";
            this.btnUpdateVac.UseVisualStyleBackColor = true;
            // 
            // btnAddVac
            // 
            this.btnAddVac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVac.Location = new System.Drawing.Point(7, 174);
            this.btnAddVac.Name = "btnAddVac";
            this.btnAddVac.Size = new System.Drawing.Size(119, 41);
            this.btnAddVac.TabIndex = 5;
            this.btnAddVac.Text = "Add";
            this.btnAddVac.UseVisualStyleBackColor = true;
            // 
            // txtVacNote
            // 
            this.txtVacNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVacNote.Location = new System.Drawing.Point(6, 116);
            this.txtVacNote.Name = "txtVacNote";
            this.txtVacNote.Size = new System.Drawing.Size(331, 34);
            this.txtVacNote.TabIndex = 4;
            // 
            // dtpNextInjectionDate
            // 
            this.dtpNextInjectionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNextInjectionDate.Location = new System.Drawing.Point(382, 120);
            this.dtpNextInjectionDate.Name = "dtpNextInjectionDate";
            this.dtpNextInjectionDate.Size = new System.Drawing.Size(335, 30);
            this.dtpNextInjectionDate.TabIndex = 3;
            // 
            // dtpInjectionDate
            // 
            this.dtpInjectionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInjectionDate.Location = new System.Drawing.Point(382, 47);
            this.dtpInjectionDate.Name = "dtpInjectionDate";
            this.dtpInjectionDate.Size = new System.Drawing.Size(335, 30);
            this.dtpInjectionDate.TabIndex = 2;
            // 
            // txtVaccineName
            // 
            this.txtVaccineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVaccineName.Location = new System.Drawing.Point(193, 43);
            this.txtVaccineName.Name = "txtVaccineName";
            this.txtVaccineName.Size = new System.Drawing.Size(144, 34);
            this.txtVaccineName.TabIndex = 1;
            // 
            // txtVacPetID
            // 
            this.txtVacPetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVacPetID.Location = new System.Drawing.Point(7, 43);
            this.txtVacPetID.Name = "txtVacPetID";
            this.txtVacPetID.Size = new System.Drawing.Size(144, 34);
            this.txtVacPetID.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(619, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ManageProForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label1);
            this.Name = "ManageProForm";
            this.Text = "ManageProForm";
            this.Load += new System.EventHandler(this.ManageProForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPet.ResumeLayout(false);
            this.tabPet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPets)).EndInit();
            this.tabVaccine.ResumeLayout(false);
            this.tabVaccine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPet;
        private System.Windows.Forms.TabPage tabVaccine;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button btnSearchPet;
        private System.Windows.Forms.Button btnDeletePet;
        private System.Windows.Forms.Button btnUpdatePet;
        private System.Windows.Forms.Button btnAddPet;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtOwnerName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtBreed;
        private System.Windows.Forms.TextBox txtSpecies;
        private System.Windows.Forms.TextBox txtPetName;
        private System.Windows.Forms.TextBox txtPetID;
        private System.Windows.Forms.DataGridView dgvVaccines;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchVac;
        private System.Windows.Forms.Button btnDeleteVac;
        private System.Windows.Forms.Button btnUpdateVac;
        private System.Windows.Forms.Button btnAddVac;
        private System.Windows.Forms.TextBox txtVacNote;
        private System.Windows.Forms.DateTimePicker dtpNextInjectionDate;
        private System.Windows.Forms.DateTimePicker dtpInjectionDate;
        private System.Windows.Forms.TextBox txtVaccineName;
        private System.Windows.Forms.TextBox txtVacPetID;
        private System.Windows.Forms.DataGridView dgvPets;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClose;
    }
}