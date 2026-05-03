using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ManageForm
{
    public partial class PetForm : Form
    {
        private string selectedImagePath = "";
        public PetForm()
        {
            InitializeComponent();
            LoadPetGrid();
        }
        private string _petID;
        private string _petName;

        // Constructor nhận petID từ OwnerForm
        public PetForm(string petID, string petName)
        {
            InitializeComponent();
            _petID = petID;
            _petName = petName;
        }


        private void PetForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_petID))
            {
                this.Text = $"Pet — {_petName}";
                txtPetID.Text = _petID;
                txtPetName.Text = _petName;
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
            dgvPets.Columns.Add("Age", "Age");
            dgvPets.Columns.Add("OwnerName", "Owner Name");
            dgvPets.Columns.Add("Note", "Note");
            dgvPets.Columns.Add("ImagePath", "Image Path");
            dgvPets.Columns["ImagePath"].Visible = false;
            // dữ liệu mẫu
            dgvPets.Rows.Add("1", "Mimi", "Cat", "British Shorthair", "2", "Thuận", "Healthy");
            dgvPets.Rows.Add("2", "Lucky", "Dog", "Poodle", "3", "An", "Needs grooming");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPetID.Text.Trim() == "" || txtPetName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Pet ID và Pet Name!");
                return;
            }

            foreach (DataGridViewRow row in dgvPets.Rows)
            {
                if (row.Cells["PetID"].Value != null &&
                    row.Cells["PetID"].Value.ToString() == txtPetID.Text.Trim())
                {
                    MessageBox.Show("Pet ID đã tồn tại!");
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
                txtNote.Text.Trim(),
                selectedImagePath
            );

            MessageBox.Show("Đã thêm thành công!");
            ClearInput();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvPets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn pet cần sửa!");
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
            dgvPets.Rows[i].Cells["ImagePath"].Value = selectedImagePath;

            MessageBox.Show("Đã sửa thành công!");
            ClearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn pet cần xóa!");
                return;
            }

            dgvPets.Rows.RemoveAt(dgvPets.SelectedRows[0].Index);
            MessageBox.Show("Đã xóa thành công!");
            ClearInput();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtPetID.Text.Trim();

            if (id == "")
            {
                MessageBox.Show("Vui lòng nhập Pet ID để tìm!");
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
                    txtNote.Text = row.Cells["Note"].Value.ToString();

                    return;
                }
            }

            MessageBox.Show("Không tìm thấy pet!");
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

                selectedImagePath = row.Cells["ImagePath"].Value?.ToString();

                if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
                {
                    petPictureBox.Image = Image.FromFile(selectedImagePath);
                    petPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    petPictureBox.Image = null;
                }
            }
        }

        private void ClearInput()
        {
            txtPetID.Clear();
            txtPetName.Clear();
            txtSpecies.Clear();
            txtBreed.Clear();
            txtAge.Clear();
            txtOwnerName.Clear();
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
    }
}