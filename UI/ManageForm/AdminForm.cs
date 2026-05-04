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
    public partial class AdminForm : Form
    {
        private string _adminName;

        public AdminForm(string adminName = "Admin")
        {
            InitializeComponent();
            _adminName = adminName;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            lblAdminName.Text = _adminName;
            btnViewDetail.Visible = false;
            btnSendNotification.Visible = false;
            LoadOwnerGrid();
        }

        private void LoadOwnerGrid()
        {
            dgvOwners.Columns.Clear();
            dgvOwners.Rows.Clear();

            dgvOwners.Columns.Add("OwnerID", "ID");
            dgvOwners.Columns.Add("OwnerName", "Họ tên");
            dgvOwners.Columns.Add("Email", "Email");
            dgvOwners.Columns.Add("Phone", "Số điện thoại");
            dgvOwners.Columns.Add("PetCount", "Số pet");
            dgvOwners.Columns.Add("Role", "Role");

            dgvOwners.Rows.Add("1", "Tran Van A", "tranvana@mail.com", "0901234567", "3", "Owner");
            dgvOwners.Rows.Add("2", "Nguyen Van B", "nguyenvanb@mail.com", "0912345678", "1", "Owner");
            dgvOwners.Rows.Add("3", "Le Van C", "levanc@mail.com", "0923456789", "2", "Admin");
        }

        private void dgvOwners_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOwners.Rows[e.RowIndex];
                txtOwnerID.Text = row.Cells["OwnerID"].Value?.ToString();
                txtOwnerName.Text = row.Cells["OwnerName"].Value?.ToString();
                txtOwnerEmail.Text = row.Cells["Email"].Value?.ToString();
                txtOwnerPhone.Text = row.Cells["Phone"].Value?.ToString();

                btnViewDetail.Visible = true;
                btnSendNotification.Visible = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtOwnerID.Text.Trim() == "" || txtOwnerName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Owner ID và Họ tên!", "Thông báo");
                return;
            }

            foreach (DataGridViewRow row in dgvOwners.Rows)
            {
                if (row.Cells["OwnerID"].Value != null &&
                    row.Cells["OwnerID"].Value.ToString() == txtOwnerID.Text.Trim())
                {
                    MessageBox.Show("Owner ID đã tồn tại!", "Thông báo");
                    return;
                }
            }

            dgvOwners.Rows.Add(
                txtOwnerID.Text.Trim(),
                txtOwnerName.Text.Trim(),
                txtOwnerEmail.Text.Trim(),
                txtOwnerPhone.Text.Trim(),
                "0",
                "Owner"
            );

            MessageBox.Show("Đã thêm thành công!", "Thông báo");
            ClearInput();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvOwners.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn owner cần sửa!", "Thông báo");
                return;
            }

            int i = dgvOwners.SelectedRows[0].Index;
            dgvOwners.Rows[i].Cells["OwnerID"].Value = txtOwnerID.Text.Trim();
            dgvOwners.Rows[i].Cells["OwnerName"].Value = txtOwnerName.Text.Trim();
            dgvOwners.Rows[i].Cells["Email"].Value = txtOwnerEmail.Text.Trim();
            dgvOwners.Rows[i].Cells["Phone"].Value = txtOwnerPhone.Text.Trim();

            MessageBox.Show("Đã sửa thành công!", "Thông báo");
            ClearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOwners.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn owner cần xóa!", "Thông báo");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa owner này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                dgvOwners.Rows.RemoveAt(dgvOwners.SelectedRows[0].Index);
                MessageBox.Show("Đã xóa thành công!", "Thông báo");
                ClearInput();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtOwnerID.Text.Trim();

            if (id == "")
            {
                MessageBox.Show("Vui lòng nhập Owner ID để tìm!", "Thông báo");
                return;
            }

            foreach (DataGridViewRow row in dgvOwners.Rows)
            {
                if (row.Cells["OwnerID"].Value != null &&
                    row.Cells["OwnerID"].Value.ToString() == id)
                {
                    row.Selected = true;
                    dgvOwners.FirstDisplayedScrollingRowIndex = row.Index;
                    txtOwnerID.Text = row.Cells["OwnerID"].Value.ToString();
                    txtOwnerName.Text = row.Cells["OwnerName"].Value.ToString();
                    txtOwnerEmail.Text = row.Cells["Email"].Value.ToString();
                    txtOwnerPhone.Text = row.Cells["Phone"].Value.ToString();
                    return;
                }
            }

            MessageBox.Show("Không tìm thấy owner!", "Thông báo");
        }

        private void btnManagePro_Click_1(object sender, EventArgs e)
        {
            ManageProForm manageProForm = new ManageProForm();
            manageProForm.Show();
        }

        private void btnViewDetail_Click_1(object sender, EventArgs e)
        {
            if (dgvOwners.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn owner!", "Thông báo");
                return;
            }
            string ownerName = dgvOwners.SelectedRows[0].Cells["OwnerName"].Value.ToString();
            OwnerForm ownerForm = new OwnerForm(ownerName, "admin");
            ownerForm.Show();
        }

        private void btnSendNotification_Click(object sender, EventArgs e)
        {
            if (dgvOwners.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn owner!", "Thông báo");
                return;
            }
            string ownerName = dgvOwners.SelectedRows[0].Cells["OwnerName"].Value.ToString();
            MessageBox.Show($"Gửi thông báo tới {ownerName}", "Thông báo");
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ClearInput()
        {
            txtOwnerID.Clear();
            txtOwnerName.Clear();
            txtOwnerEmail.Clear();
            txtOwnerPhone.Clear();
        }

        private void txtOwnerID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}