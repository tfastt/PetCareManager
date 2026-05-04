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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = textBox1.Text.Trim();         // textBox1 = Họ Và Tên
            string email = txtEmail.Text.Trim();             // txtEmail = Email
            string password = textBox2.Text.Trim();          // textBox2 = Password
            string confirmPassword = txtConfirmPassword.Text.Trim(); // txtConfirmPassword = Confirm

            if (fullName == "" || email == "" || password == "" || confirmPassword == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo");
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo");
                return;
            }

            MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thành công");
            GoToLogin();
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoToLogin();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
        private void GoToLogin()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is LoginForm)
                {
                    f.Show();
                    break;
                }
            }
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
