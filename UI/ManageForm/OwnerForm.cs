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
                { "1", "Mimi" },
                { "2", "Lucky" },
                { "3", "Tom" },
                { "4", "Jerry" },
                { "5", "Kitty" },
                { "6", "Max" },
                { "7", "Bella" },
                { "8", "Charlie" },
                { "9", "Lucy" },
                { "10", "Daisy" }
            };

            //lblPetCount.Text = pets.GetLength(0) + " thú cưng";
            int cardWidth = 150;
            int cardHeight = 100;
            int padding = 10;
            int cols = 3;
            int petCount = pets.GetLength(0);
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

                string petID = pets[i, 0];
                string petName = pets[i, 1];

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
                btnEdit.Tag = petID + "|" + petName;

                btnEdit.Click += (s, ev) =>
                {
                    Button btn = s as Button;
                    string tag = btn.Tag.ToString();

                    string[] parts = tag.Split('|');
                    string pID = parts[0];
                    string pName = parts[1];

                    PetForm petForm = new PetForm(pID, pName);
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
                PetForm petForm = new PetForm();
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
    }
}