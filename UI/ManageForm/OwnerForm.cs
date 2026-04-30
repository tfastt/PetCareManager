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
    public partial class OwnerForm : Form
    {
        private string _ownerName;
        private string _role;

        public OwnerForm(string ownerName = "Owner", string role = "owner")
        {
            InitializeComponent();
            _ownerName = ownerName;
            _role = role;
        }

        private void OwnerForm_Load(object sender, EventArgs e)
        {
            LoadPetCards();
        }

        private void LoadPetCards()
        {
            pnlPets.Controls.Clear();

            // Dữ liệu mẫu
            string[,] pets = {
                { "1", "Mimi", "Cat", "British Shorthair", "2", "🐱" },
                { "2", "Lucky", "Dog", "Poodle", "3", "🐶" },
            };

            //lblPetCount.Text = pets.GetLength(0) + " thú cưng";

            int cardWidth = 180;
            int cardHeight = 180;
            int padding = 12;

            for (int i = 0; i < pets.GetLength(0); i++)
            {
                string petID = pets[i, 0];
                string petName = pets[i, 1];
                string species = pets[i, 2];
                string breed = pets[i, 3];
                string age = pets[i, 4];

                // Tạo panel card
                Panel card = new Panel();
                card.Size = new Size(cardWidth, cardHeight);
                card.Location = new Point(i * (cardWidth + padding) + padding, padding);
                card.BackColor = Color.White;
                card.BorderStyle = BorderStyle.FixedSingle;

                // Tên pet
                Label lblName = new Label();
                lblName.Text = petName;
                lblName.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
                lblName.AutoSize = false;
                lblName.Size = new Size(cardWidth - 10, 25);
                lblName.Location = new Point(5, 80);
                lblName.TextAlign = ContentAlignment.MiddleCenter;

                // Thông tin pet
                Label lblInfo = new Label();
                lblInfo.Text = breed + " · " + age + " tuổi";
                lblInfo.Font = new Font("Microsoft Sans Serif", 8);
                lblInfo.ForeColor = Color.Gray;
                lblInfo.AutoSize = false;
                lblInfo.Size = new Size(cardWidth - 10, 35);
                lblInfo.Location = new Point(5, 105);
                lblInfo.TextAlign = ContentAlignment.TopCenter;

                // Nút chỉnh sửa
                Button btnEdit = new Button();
                btnEdit.Text = "Chỉnh sửa";
                btnEdit.Size = new Size(cardWidth - 20, 30);
                btnEdit.Location = new Point(10, 140);
                btnEdit.BackColor = Color.FromArgb(24, 95, 165);
                btnEdit.ForeColor = Color.White;
                btnEdit.FlatStyle = FlatStyle.Flat;
                btnEdit.Tag = petID + "|" + petName; // lưu petID để truyền sang PetForm

                btnEdit.Click += (s, ev) =>
                {
                    string tag = btnEdit.Tag.ToString();
                    string[] parts = tag.Split('|');
                    string pID = parts[0];
                    string pName = parts[1];

                    PetForm petForm = new PetForm(pID, pName);
                    petForm.Show();
                };

                card.Controls.Add(lblName);
                card.Controls.Add(lblInfo);
                card.Controls.Add(btnEdit);
                pnlPets.Controls.Add(card);
            }

            // Card thêm mới
            Panel addCard = new Panel();
            addCard.Size = new Size(cardWidth, cardHeight);
            addCard.Location = new Point(pets.GetLength(0) * (cardWidth + padding) + padding, padding);
            addCard.BackColor = Color.White;
            addCard.BorderStyle = BorderStyle.FixedSingle;
            addCard.Cursor = Cursors.Hand;

            Label lblAdd = new Label();
            lblAdd.Text = "+ Thêm thú cưng";
            lblAdd.Font = new Font("Microsoft Sans Serif", 10);
            lblAdd.ForeColor = Color.Gray;
            lblAdd.AutoSize = false;
            lblAdd.Size = new Size(cardWidth - 10, cardHeight);
            lblAdd.Location = new Point(5, 0);
            lblAdd.TextAlign = ContentAlignment.MiddleCenter;

            addCard.Controls.Add(lblAdd);
            addCard.Click += (s, ev) =>
            {
                PetForm petForm = new PetForm();
                petForm.Show();
            };

            pnlPets.Controls.Add(addCard);
        }

        private void btnSysInfo_Click(object sender, EventArgs e)
        {
            SystemInfoForm sysInfoForm = new SystemInfoForm();
            sysInfoForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
        "Bạn có chắc muốn đăng xuất?", "Xác nhận",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }
    }
}