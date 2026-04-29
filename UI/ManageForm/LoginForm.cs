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

            // Tạm thời dùng tài khoản cứng, sau kết nối DB sẽ thay
            if (email == "admin@petcare.vn" && password == "admin123")
            {
                // Đăng nhập với role Admin
                Form1 mainForm = new Form1("admin");
                mainForm.Show();
                this.Hide();
            }
            else if (email == "owner@petcare.vn" && password == "owner123")
            {
                // Đăng nhập với role Owner
                Form1 mainForm = new Form1("owner");
                mainForm.Show();
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
            SystemInfoForm sysInfoForm = new SystemInfoForm();
            sysInfoForm.Show();
            this.Hide();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}