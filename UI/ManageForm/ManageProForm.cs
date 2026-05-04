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
    public partial class ManageProForm : Form
    {
        public ManageProForm()
        {
            InitializeComponent();
        }

        private void ManageProForm_Load(object sender, EventArgs e)
        {
            LoadPetGrid();
            LoadVaccineGrid();
        }

        // ==================== PET ====================

        private void LoadPetGrid()
        {
            dgvPets.Columns.Clear();
            dgvPets.Rows.Clear();

            dgvPets.Columns.Add("SpeciesID", "ID");
            dgvPets.Columns.Add("SpeciesName", "Tên loài");
            dgvPets.Columns.Add("Description", "Mô tả");

            // Danh mục loài pet của hệ thống
            dgvPets.Rows.Add("1", "Cat", "Mèo");
            dgvPets.Rows.Add("2", "Dog", "Chó");
            dgvPets.Rows.Add("3", "Rabbit", "Thỏ");
            dgvPets.Rows.Add("4", "Bird", "Chim");
            dgvPets.Rows.Add("5", "Fish", "Cá");
        }

        private void btnAddPet_Click(object sender, EventArgs e)
        {
            if (txtPetID.Text.Trim() == "" || txtPetName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Pet ID và Pet Name!", "Thông báo");
                return;
            }

            foreach (DataGridViewRow row in dgvPets.Rows)
            {
                if (row.Cells["PetID"].Value != null &&
                    row.Cells["PetID"].Value.ToString() == txtPetID.Text.Trim())
                {
                    MessageBox.Show("Pet ID đã tồn tại!", "Thông báo");
                    return;
                }
            }

            dgvPets.Rows.Add(
                txtPetID.Text.Trim(),
                txtPetName.Text.Trim(),
                txtSpecies.Text.Trim(),
                txtBreed.Text.Trim(),
                txtAge.Text.Trim(),
                txtOwnerName.Text.Trim(),
                txtNote.Text.Trim()
            );

            MessageBox.Show("Đã thêm pet thành công!", "Thông báo");
            ClearPetInput();
        }

        private void btnUpdatePet_Click(object sender, EventArgs e)
        {
            if (dgvPets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn pet cần sửa!", "Thông báo");
                return;
            }

            int i = dgvPets.SelectedRows[0].Index;
            dgvPets.Rows[i].Cells["PetID"].Value = txtPetID.Text.Trim();
            dgvPets.Rows[i].Cells["PetName"].Value = txtPetName.Text.Trim();
            dgvPets.Rows[i].Cells["Species"].Value = txtSpecies.Text.Trim();
            dgvPets.Rows[i].Cells["Breed"].Value = txtBreed.Text.Trim();
            dgvPets.Rows[i].Cells["Age"].Value = txtAge.Text.Trim();
            dgvPets.Rows[i].Cells["OwnerName"].Value = txtOwnerName.Text.Trim();
            dgvPets.Rows[i].Cells["Note"].Value = txtNote.Text.Trim();

            MessageBox.Show("Đã sửa pet thành công!", "Thông báo");
            ClearPetInput();
        }

        private void btnDeletePet_Click(object sender, EventArgs e)
        {
            if (dgvPets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn pet cần xóa!", "Thông báo");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa pet này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                dgvPets.Rows.RemoveAt(dgvPets.SelectedRows[0].Index);
                MessageBox.Show("Đã xóa pet thành công!", "Thông báo");
                ClearPetInput();
            }
        }

        private void btnSearchPet_Click(object sender, EventArgs e)
        {
            string id = txtPetID.Text.Trim();
            if (id == "")
            {
                MessageBox.Show("Vui lòng nhập Pet ID để tìm!", "Thông báo");
                return;
            }

            foreach (DataGridViewRow row in dgvPets.Rows)
            {
                if (row.Cells["PetID"].Value != null &&
                    row.Cells["PetID"].Value.ToString() == id)
                {
                    row.Selected = true;
                    dgvPets.FirstDisplayedScrollingRowIndex = row.Index;
                    txtPetID.Text = row.Cells["PetID"].Value.ToString();
                    txtPetName.Text = row.Cells["PetName"].Value.ToString();
                    txtSpecies.Text = row.Cells["Species"].Value.ToString();
                    txtBreed.Text = row.Cells["Breed"].Value.ToString();
                    txtAge.Text = row.Cells["Age"].Value.ToString();
                    txtOwnerName.Text = row.Cells["OwnerName"].Value.ToString();
                    txtNote.Text = row.Cells["Note"].Value?.ToString();
                    return;
                }
            }
            MessageBox.Show("Không tìm thấy pet!", "Thông báo");
        }

        private void dgvPets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPets.Rows[e.RowIndex];
                txtPetID.Text = row.Cells["PetID"].Value?.ToString();
                txtPetName.Text = row.Cells["PetName"].Value?.ToString();
                txtSpecies.Text = row.Cells["Species"].Value?.ToString();
                txtBreed.Text = row.Cells["Breed"].Value?.ToString();
                txtAge.Text = row.Cells["Age"].Value?.ToString();
                txtOwnerName.Text = row.Cells["OwnerName"].Value?.ToString();
                txtNote.Text = row.Cells["Note"].Value?.ToString();
            }
        }

        private void ClearPetInput()
        {
            txtPetID.Clear(); txtPetName.Clear();
            txtSpecies.Clear(); txtBreed.Clear();
            txtAge.Clear(); txtOwnerName.Clear();
            txtNote.Clear();
        }

        // ==================== VACCINE ====================

        private void LoadVaccineGrid()
        {
            dgvVaccines.Columns.Clear();
            dgvVaccines.Rows.Clear();

            dgvVaccines.Columns.Add("VaccineID", "ID");
            dgvVaccines.Columns.Add("VaccineName", "Tên vaccine");
            dgvVaccines.Columns.Add("ForSpecies", "Dành cho");
            dgvVaccines.Columns.Add("Description", "Mô tả");

            // Danh mục vaccine của hệ thống
            dgvVaccines.Rows.Add("1", "Rabies", "Cat, Dog", "Vaccine phòng dại");
            dgvVaccines.Rows.Add("2", "FVRCP", "Cat", "Vaccine tổng hợp mèo");
            dgvVaccines.Rows.Add("3", "DA2PP", "Dog", "Vaccine tổng hợp chó");
            dgvVaccines.Rows.Add("4", "Bordetella", "Dog", "Vaccine viêm phế quản");
            dgvVaccines.Rows.Add("5", "RHDV", "Rabbit", "Vaccine xuất huyết thỏ");
        }

        private void btnAddVac_Click(object sender, EventArgs e)
        {
            if (txtVaccineName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên vaccine!", "Thông báo");
                return;
            }

            dgvVaccines.Rows.Add(
                txtVacPetID.Text.Trim(),
                txtVaccineName.Text.Trim(),
                dtpInjectionDate.Value.ToString("dd/MM/yyyy"),
                dtpNextInjectionDate.Value.ToString("dd/MM/yyyy"),
                txtVacNote.Text.Trim()
            );

            MessageBox.Show("Đã thêm vaccine thành công!", "Thông báo");
            ClearVacInput();
        }

        private void btnUpdateVac_Click(object sender, EventArgs e)
        {
            if (dgvVaccines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vaccine cần sửa!", "Thông báo");
                return;
            }

            int i = dgvVaccines.SelectedRows[0].Index;
            dgvVaccines.Rows[i].Cells["PetID"].Value = txtVacPetID.Text.Trim();
            dgvVaccines.Rows[i].Cells["VaccineName"].Value = txtVaccineName.Text.Trim();
            dgvVaccines.Rows[i].Cells["InjectionDate"].Value = dtpInjectionDate.Value.ToString("dd/MM/yyyy");
            dgvVaccines.Rows[i].Cells["NextInjectionDate"].Value = dtpNextInjectionDate.Value.ToString("dd/MM/yyyy");
            dgvVaccines.Rows[i].Cells["Note"].Value = txtVacNote.Text.Trim();

            MessageBox.Show("Đã sửa vaccine thành công!", "Thông báo");
            ClearVacInput();
        }

        private void btnDeleteVac_Click(object sender, EventArgs e)
        {
            if (dgvVaccines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vaccine cần xóa!", "Thông báo");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa vaccine này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                dgvVaccines.Rows.RemoveAt(dgvVaccines.SelectedRows[0].Index);
                MessageBox.Show("Đã xóa vaccine thành công!", "Thông báo");
                ClearVacInput();
            }
        }

        private void btnSearchVac_Click(object sender, EventArgs e)
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
                    txtVacPetID.Text = row.Cells["PetID"].Value?.ToString();
                    txtVaccineName.Text = row.Cells["VaccineName"].Value?.ToString();
                    txtVacNote.Text = row.Cells["Note"].Value?.ToString();
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
                txtVacPetID.Text = row.Cells["PetID"].Value?.ToString();
                txtVaccineName.Text = row.Cells["VaccineName"].Value?.ToString();
                txtVacNote.Text = row.Cells["Note"].Value?.ToString();
            }
        }

        private void ClearVacInput()
        {
            txtVacPetID.Clear();
            txtVaccineName.Clear();
            txtVacNote.Clear();
            dtpInjectionDate.Value = DateTime.Now;
            dtpNextInjectionDate.Value = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}