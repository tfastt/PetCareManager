using PetCareManager.DataAccess;
using PetCareManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageForm
{
    public partial class PetForm : Form
    {
        PetRepository _repo = new PetRepository();
        private int _userId;
        private string selectedImagePath = "";
        public PetForm()
        {
            InitializeComponent();
            LoadPetGrid();
        }
        private string _petID;
        private string _petName;

        public PetForm(int userId, int petID)
        {
            InitializeComponent();
            _userId = userId;
            _petID = petID.ToString();
        }


        private void PetForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_petID))
            {
                this.Text = $"Pet — {_petName}";
                txtPetID.Text = _petID;
                txtPetName.Text = _petName;
                cboGender.Items.Clear();
                cboGender.Items.Add("Male");
                cboGender.Items.Add("Female");
            }
            LoadPetGrid();
        }
        private void LoadPetGrid()
        {
            dgvPets.Columns.Clear();
            dgvPets.Rows.Clear();

            dgvPets.Columns.Add("PetID", "Pet ID");
            dgvPets.Columns.Add("PetName", "Pet Name");
            dgvPets.Columns.Add("Species", "Species");
            dgvPets.Columns.Add("Breed", "Breed");
            dgvPets.Columns.Add("Weight", "Weight");
            dgvPets.Columns.Add("HealthStatus", "Health");
            dgvPets.Columns.Add("Note", "Note");

            var pets = _repo.GetAllPets()
                            .Where(p => p.UserID == _userId)
                            .ToList();

            foreach (var p in pets)
            {
                dgvPets.Rows.Add(
                    p.PetID,
                    p.PetName,
                    p.Species,
                    p.Breed,
                    p.Weight,
                    p.HealthStatus,
                    p.Note
                );
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPetName.Text))
            {
                MessageBox.Show("Nhập tên pet!");
                return;
            }

            if (cboGender.SelectedItem == null)
            {
                MessageBox.Show("Chọn giới tính!");
                return;
            }

            double weight;
            if (!double.TryParse(txtAge.Text, out weight))
            {
                MessageBox.Show("Weight phải là số!");
                return;
            }

            Pet pet = new Pet()
            {
                PetName = txtPetName.Text.Trim(),
                Species = txtSpecies.Text.Trim(),
                Breed = txtBreed.Text.Trim(),
                DateOfBirth = DateTime.Now, // tạm thời
                Weight = weight,
                HealthStatus = "Normal",
                UserID = _userId,
                Gender = (Gender)Enum.Parse(typeof(Gender), cboGender.SelectedItem.ToString()),
                Note = txtNote.Text.Trim()
            };

            _repo.AddPet(pet);

            MessageBox.Show("Thêm thành công!");
            LoadPetGrid();
            ClearInput();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvPets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn pet cần sửa!");
                return;
            }

            if (cboGender.SelectedItem == null)
            {
                MessageBox.Show("Chọn giới tính!");
                return;
            }

            double weight;
            if (!double.TryParse(txtAge.Text, out weight))
            {
                MessageBox.Show("Weight phải là số!");
                return;
            }

            int id = (int)dgvPets.SelectedRows[0].Cells["PetID"].Value;

            Pet pet = new Pet()
            {
                PetID = id,
                PetName = txtPetName.Text.Trim(),
                Species = txtSpecies.Text.Trim(),
                Breed = txtBreed.Text.Trim(),
                DateOfBirth = DateTime.Now,
                Weight = weight,
                HealthStatus = "Normal",
                UserID = _userId,
                Gender = (Gender)Enum.Parse(typeof(Gender), cboGender.SelectedItem.ToString()),
                Note = txtNote.Text.Trim()
            };

            _repo.UpdatePet(pet);

            MessageBox.Show("Cập nhật thành công!");
            LoadPetGrid();
            ClearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn pet để xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.No) return;

            int id = (int)dgvPets.SelectedRows[0].Cells["PetID"].Value;

            _repo.DeletePet(id);

            MessageBox.Show("Xóa thành công!");
            LoadPetGrid();
            ClearInput();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtPetID.Text.Trim();

            if (id == "")
            {
                MessageBox.Show("Nhập Pet ID!");
                return;
            }

            foreach (DataGridViewRow row in dgvPets.Rows)
            {
                if (row.Cells["PetID"]?.Value?.ToString() == id)
                {
                    row.Selected = true;
                    dgvPets.FirstDisplayedScrollingRowIndex = row.Index;

                    txtPetID.Text = row.Cells["PetID"]?.Value?.ToString() ?? "";
                    txtPetName.Text = row.Cells["PetName"]?.Value?.ToString() ?? "";
                    txtSpecies.Text = row.Cells["Species"]?.Value?.ToString() ?? "";
                    txtBreed.Text = row.Cells["Breed"]?.Value?.ToString() ?? "";
                    txtAge.Text = row.Cells["Weight"]?.Value?.ToString() ?? ""; // 
                    txtNote.Text = row.Cells["Note"]?.Value?.ToString() ?? "";

                    return;
                }
            }

            MessageBox.Show("Không tìm thấy!");
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
                txtNote.Text = row.Cells["Note"].Value?.ToString();
                petPictureBox.Image = null;
            }
        }

        private void ClearInput()
        {
            txtPetID.Clear();
            txtPetName.Clear();
            txtSpecies.Clear();
            txtBreed.Clear();
            txtAge.Clear();
            txtNote.Clear();
            selectedImagePath = "";
            petPictureBox.Image = null;
        }

        private void txtPetID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Age_Click(object sender, EventArgs e)
        {

        }

        private void Breed_Click(object sender, EventArgs e)
        {

        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(openFileDialog.FileName);
                selectedImagePath = openFileDialog.FileName;
                petPictureBox.Image = new Bitmap(openFileDialog.FileName);
                petPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void btnEditVaccine_Click(object sender, EventArgs e)
        {
            if (dgvPets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn pet trước!", "Thông báo");
                return;
            }

            string petID = dgvPets.SelectedRows[0].Cells["PetID"].Value.ToString();
            string petName = dgvPets.SelectedRows[0].Cells["PetName"].Value.ToString();

            VaccineForm vaccineForm = new VaccineForm(petID, petName);
            vaccineForm.Show();
        }

        private void txtSpecies_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }
    }
}