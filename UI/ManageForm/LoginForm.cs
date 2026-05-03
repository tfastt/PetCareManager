using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
using System.Windows.Forms;

namespace ManageForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (email == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu!", "Thông báo");
                return;
            }

            // Tài khoản Admin
            if (email == "admin@petcare.vn" && password == "admin123")
            {
                AdminForm adminForm = new AdminForm("Admin");
                adminForm.FormClosed += (s, ev) => this.Show();
                adminForm.Show();
                this.Hide();
            }
            // Tài khoản Owner
            else if (email == "owner@petcare.vn" && password == "owner123")
            {
                OwnerForm ownerForm = new OwnerForm("Nguyễn Thuận", "owner");
                ownerForm.FormClosed += (s, ev) => this.Show();
                ownerForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Email hoặc mật khẩu không đúng!", "Lỗi");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void lnkSysInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SystemInfoForm sysInfoForm = new SystemInfoForm(this);
            sysInfoForm.Show();
            this.Hide();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.FormClosed += (s, ev) => this.Show();
            registerForm.Show();
            this.Hide();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}