using PetCareManager.DataAccess;
using PetCareManager.Model;
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
        private int _userId;

        public OwnerForm(int userId, string ownerName, string role)
        {
            InitializeComponent();
            _userId = userId;
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
            PetRepository repo = new PetRepository();
            var allPets = repo.GetAllPets();
            var pets = allPets.Where(p => p.UserID == _userId).ToList();

            int cardWidth = 150;
            int cardHeight = 100;
            int padding = 10;
            int cols = 3;

            int petCount = pets.Count;
            int totalCards = petCount + 1; // +1 cho card "Add"
            int rows = (int)Math.Ceiling((double)totalCards / cols);
            // Set scroll cho panel
            pnlPets.AutoScroll = true;
            int panelHeight = rows * (cardHeight + padding) + padding;
            pnlPets.AutoScrollMinSize = new Size(0, panelHeight);

            for (int i = 0; i < petCount; i++)
            {
                int row = i / cols;
                int col = i % cols;

                int x = col * (cardWidth + padding) + padding;
                int y = row * (cardHeight + padding) + padding;

                var pet = pets[i];
                string petID = pet.PetID.ToString();
                string petName = pet.PetName;

                Panel card = new Panel();
                card.Size = new Size(cardWidth, cardHeight);
                card.Location = new Point(x, y);
                card.BackColor = Color.LightBlue;
                card.BorderStyle = BorderStyle.FixedSingle;

                Label lbl = new Label();
                lbl.Text = petName;
                lbl.Dock = DockStyle.Top;
                lbl.Height = 40;
                lbl.TextAlign = ContentAlignment.MiddleCenter;

                Button btnEdit = new Button();
                btnEdit.Text = "Chỉnh sửa";
                btnEdit.Size = new Size(cardWidth - 20, 30);
                btnEdit.Location = new Point(10, cardHeight - 40);
                btnEdit.BackColor = Color.FromArgb(24, 95, 165);
                btnEdit.ForeColor = Color.White;
                btnEdit.FlatStyle = FlatStyle.Flat;
                btnEdit.Tag = pet.PetID;

                btnEdit.Click += (s, ev) =>
                {
                    int petId = (int)((Button)s).Tag;
                    PetForm petForm = new PetForm( _userId, petId);
                    petForm.Show();
                };

                card.Controls.Add(lbl);
                card.Controls.Add(btnEdit); 

                pnlPets.Controls.Add(card);
            }

            // 🔹 6. Card "+ Thêm thú cưng"
            int iAdd = petCount;
            int rowAdd = iAdd / cols;
            int colAdd = iAdd % cols;

            int xAdd = colAdd * (cardWidth + padding) + padding;
            int yAdd = rowAdd * (cardHeight + padding) + padding;

            Panel addCard = new Panel();
            addCard.Size = new Size(cardWidth, cardHeight);
            addCard.Location = new Point(xAdd, yAdd);
            addCard.BackColor = Color.White;
            addCard.BorderStyle = BorderStyle.FixedSingle;
            addCard.Cursor = Cursors.Hand;

            Label lblAdd = new Label();
            lblAdd.Text = "+ Thêm thú cưng";
            lblAdd.Dock = DockStyle.Fill;
            lblAdd.TextAlign = ContentAlignment.MiddleCenter;
            lblAdd.ForeColor = Color.Gray;

            addCard.Controls.Add(lblAdd);

            // 👉 Click mở PetForm
            lblAdd.Click += (s, ev) =>
            {
                PetForm petForm = new PetForm(_userId, petCount);
                petForm.Show();
            };

            pnlPets.Controls.Add(addCard);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSysInfo_Click_1(object sender, EventArgs e)
        {
            SystemInfoForm sysInfoForm = new SystemInfoForm(this);
            sysInfoForm.Show();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}