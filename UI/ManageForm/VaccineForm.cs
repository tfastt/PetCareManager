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
    public partial class VaccineForm : Form
    {
        private string _petID;
        private string _petName;
        private string _role;

        // Constructor khi mở từ PetForm
        public VaccineForm(string petID, string petName, string role = "owner")
        {
            InitializeComponent();
            _petID = petID;
            _petName = petName;
            _role = role;
        }

        // Constructor mặc định
        public VaccineForm()
        {
            InitializeComponent();
            _role = "owner";
        }

        private void VaccineForm_Load(object sender, EventArgs e)
        {
            // Hiện tên pet trên title
            this.Text = string.IsNullOrEmpty(_petName)
                ? "Vaccine Management"
                : $"Vaccine Management — {_petName}";

            // Điền Pet ID vào textbox
            txtPetID.Text = _petID;

            // Ẩn/hiện nút Manage Pro theo role
            btnManagePro.Visible = (_role == "admin");

            LoadVaccineGrid();
        }

        private void LoadVaccineGrid()
        {
            dgvVaccines.Columns.Clear();
            dgvVaccines.Rows.Clear();

            dgvVaccines.Columns.Add("VaccineName", "Vaccine Name");
            dgvVaccines.Columns.Add("InjectionDate", "Injection Date");
            dgvVaccines.Columns.Add("NextInjectionDate", "Next Injection");
            dgvVaccines.Columns.Add("Note", "Note");

            // Dữ liệu mẫu
            dgvVaccines.Rows.Add("Rabies", "01/01/2025", "01/01/2026", "Đã tiêm xong");
            dgvVaccines.Rows.Add("FVRCP", "15/03/2025", "15/03/2026", "Bình thường");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtVaccineName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên vaccine!", "Thông báo");
                return;
            }

            dgvVaccines.Rows.Add(
                txtVaccineName.Text.Trim(),
                dtpInjectionDate.Value.ToString("dd/MM/yyyy"),
                dtpNextInjectionDate.Value.ToString("dd/MM/yyyy"),
                txtNote.Text.Trim()
            );

            MessageBox.Show("Đã thêm thành công!", "Thông báo");
            ClearInput();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvVaccines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vaccine cần sửa!", "Thông báo");
                return;
            }

            int i = dgvVaccines.SelectedRows[0].Index;
            dgvVaccines.Rows[i].Cells["VaccineName"].Value = txtVaccineName.Text.Trim();
            dgvVaccines.Rows[i].Cells["InjectionDate"].Value = dtpInjectionDate.Value.ToString("dd/MM/yyyy");
            dgvVaccines.Rows[i].Cells["NextInjectionDate"].Value = dtpNextInjectionDate.Value.ToString("dd/MM/yyyy");
            dgvVaccines.Rows[i].Cells["Note"].Value = txtNote.Text.Trim();

            MessageBox.Show("Đã sửa thành công!", "Thông báo");
            ClearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVaccines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vaccine cần xóa!", "Thông báo");
                return;
            }

            dgvVaccines.Rows.RemoveAt(dgvVaccines.SelectedRows[0].Index);
            MessageBox.Show("Đã xóa thành công!", "Thông báo");
            ClearInput();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtVaccineName.Text.Trim();

            if (name == "")
            {
                MessageBox.Show("Vui lòng nhập tên vaccine để tìm!", "Thông báo");
                return;
            }

            foreach (DataGridViewRow row in dgvVaccines.Rows)
            {
                if (row.Cells["VaccineName"].Value != null &&
                    row.Cells["VaccineName"].Value.ToString().ToLower().Contains(name.ToLower()))
                {
                    row.Selected = true;
                    dgvVaccines.FirstDisplayedScrollingRowIndex = row.Index;

                    txtVaccineName.Text = row.Cells["VaccineName"].Value.ToString();
                    dtpInjectionDate.Value = DateTime.ParseExact(
                        row.Cells["InjectionDate"].Value.ToString(), "dd/MM/yyyy", null);
                    dtpNextInjectionDate.Value = DateTime.ParseExact(
                        row.Cells["NextInjectionDate"].Value.ToString(), "dd/MM/yyyy", null);
                    txtNote.Text = row.Cells["Note"].Value?.ToString();
                    return;
                }
            }

            MessageBox.Show("Không tìm thấy vaccine!", "Thông báo");
        }

        private void dgvVaccines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVaccines.Rows[e.RowIndex];
                txtVaccineName.Text = row.Cells["VaccineName"].Value?.ToString();
                dtpInjectionDate.Value = DateTime.ParseExact(
                    row.Cells["InjectionDate"].Value.ToString(), "dd/MM/yyyy", null);
                dtpNextInjectionDate.Value = DateTime.ParseExact(
                    row.Cells["NextInjectionDate"].Value.ToString(), "dd/MM/yyyy", null);
                txtNote.Text = row.Cells["Note"].Value?.ToString();
            }
        }

        private void btnManagePro_Click(object sender, EventArgs e)
        {
            // Sau này mở ManageProForm
            MessageBox.Show("Chức năng Manage Pro!", "Thông báo");
        }

        private void ClearInput()
        {
            txtVaccineName.Clear();
            txtNote.Clear();
            dtpInjectionDate.Value = DateTime.Now;
            dtpNextInjectionDate.Value = DateTime.Now;
        }
    }
}