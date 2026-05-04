using PetCareManager.DataAccess;
using PetCareManager.Services.Implementations;
using PetCareManager.Services.Interfaces;
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

        private void label6_Click(object sender, EventArgs e)
        {
            GoToLogin();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            string fullName = textBox1.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = textBox2.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(fullName) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                UserRepository repo = new UserRepository();
                IAuthService authService = new AuthService(repo);

                var user = authService.Register(fullName, email, password, confirmPassword);

                if (user != null)
                {
                    MessageBox.Show("Đăng ký thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại! (Email đã tồn tại hoặc mật khẩu không khớp)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            GoToLogin();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoToLogin();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
