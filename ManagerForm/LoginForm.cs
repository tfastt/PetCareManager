using PetCareManager.DataAccess;
using PetCareManager.Model;
using PetCareManager.Services.Implementations;
using PetCareManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
using System.Windows.Forms;
namespace ManageForm
{
    public partial class LoginForm : Form
    {
        private IAuthService _authService;
        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService(new UserRepository());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                UserRepository repo = new UserRepository();
                IAuthService authService = new AuthService(repo);
                User user = authService.Login(email, password);

                if (user != null)
                {
                    MessageBox.Show("Đăng nhập thành công!");

                    if (user.Role == "Admin")
                        new AdminForm().Show();
                    else
                        new OwnerForm(user.UserID, user.UserName, user.Role).Show();
                }
                else
                {
                    MessageBox.Show("Sai Email hoặc Password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
