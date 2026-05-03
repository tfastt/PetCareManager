using ManageForm;
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
    public partial class SystemInfoForm : Form
    {
        private Form parentForm;
        public SystemInfoForm(Form form)
        {
            InitializeComponent();
            parentForm = form;
        }

        private void SystemInfoForm_Load(object sender, EventArgs e)
        {
            // Nội dung giới thiệu
            lblIntro.Text = "PetCare Manager là hệ thống giúp chủ nuôi và quản trị viên " +
                            "theo dõi toàn bộ thông tin thú cưng, lịch tiêm vaccine và " +
                            "hồ sơ sức khỏe một cách dễ dàng và hiệu quả.";

            // Nội dung hướng dẫn
            lblGuide.Text = "1. Đăng ký tài khoản hoặc đăng nhập nếu đã có.\r\n" +
                            "2. Thêm thông tin thú cưng của bạn.\r\n" +
                            "3. Theo dõi lịch tiêm vaccine và cập nhật định kỳ.\r\n" +
                            "4. Admin có thể quản lý toàn bộ hệ thống.";

            // Nội dung liên hệ
            lblContact.Text = "Email: support@petcare.vn\r\n" +
                              "Hotline: 1800 1234\r\n" +
                              "Hỗ trợ 24/7";
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }
    }
}