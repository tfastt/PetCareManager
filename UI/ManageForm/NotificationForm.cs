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
    public partial class NotificationForm : Form
    {
        // Lưu danh sách thông báo dùng chung toàn app
        public static System.Collections.Generic.List<NotificationItem> Notifications
            = new System.Collections.Generic.List<NotificationItem>();

        public NotificationForm()
        {
            InitializeComponent();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            // Thêm thông báo mẫu nếu chưa có
            if (Notifications.Count == 0)
            {
                Notifications.Add(new NotificationItem
                {
                    Title = "Nhắc nhở tiêm vaccine",
                    Description = "Mimi cần tiêm vaccine FVRCP vào ngày 15/05/2026. Còn 11 ngày nữa!",
                    Time = "Hôm nay, 08:00",
                    Type = "vaccine",
                    IsRead = false
                });
                Notifications.Add(new NotificationItem
                {
                    Title = "Nhắc nhở tiêm vaccine",
                    Description = "Lucky cần tiêm vaccine DA2PP vào ngày 20/05/2026. Còn 16 ngày nữa!",
                    Time = "Hôm nay, 08:00",
                    Type = "vaccine",
                    IsRead = false
                });
                Notifications.Add(new NotificationItem
                {
                    Title = "Thông báo từ Admin",
                    Description = "Hệ thống sẽ bảo trì vào ngày 10/05/2026 từ 22:00 - 23:00.",
                    Time = "Hôm qua, 14:30",
                    Type = "admin",
                    IsRead = false
                });
            }

            LoadNotifications();
        }

        private void LoadNotifications()
        {
            pnlAll.Controls.Clear();
            pnlVaccine.Controls.Clear();
            pnlAdmin.Controls.Clear();

            int unreadCount = 0;

            foreach (var notif in Notifications)
            {
                if (!notif.IsRead) unreadCount++;

                Panel card = CreateNotifCard(notif);

                // Thêm vào tab Tất cả
                card.Location = new Point(0, pnlAll.Controls.Count * 90);
                pnlAll.Controls.Add(card);

                // Thêm vào tab tương ứng
                if (notif.Type == "vaccine")
                {
                    Panel cardV = CreateNotifCard(notif);
                    cardV.Location = new Point(0, pnlVaccine.Controls.Count * 90);
                    pnlVaccine.Controls.Add(cardV);
                }
                else if (notif.Type == "admin")
                {
                    Panel cardA = CreateNotifCard(notif);
                    cardA.Location = new Point(0, pnlAdmin.Controls.Count * 90);
                    pnlAdmin.Controls.Add(cardA);
                }
            }

            lblCount.Text = unreadCount > 0 ? $"({unreadCount} chưa đọc)" : "";
        }

        private Panel CreateNotifCard(NotificationItem notif)
        {
            Panel card = new Panel();
            card.Size = new Size(pnlAll.Width - 20, 80);
            card.BackColor = notif.IsRead ? Color.White : Color.FromArgb(245, 249, 255);
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(0, 0, 0, 8);
            card.Cursor = Cursors.Hand;

            // Icon
            Label lblIcon = new Label();
            lblIcon.Text = notif.Type == "vaccine" ? "💉" : notif.Type == "admin" ? "📢" : "✅";
            lblIcon.Font = new Font("Segoe UI Emoji", 16);
            lblIcon.Location = new Point(10, 20);
            lblIcon.AutoSize = true;

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = notif.Title;
            lblTitle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            lblTitle.Location = new Point(50, 8);
            lblTitle.AutoSize = false;
            lblTitle.Size = new Size(card.Width - 70, 20);

            // Description
            Label lblDesc = new Label();
            lblDesc.Text = notif.Description;
            lblDesc.Font = new Font("Microsoft Sans Serif", 8.5f);
            lblDesc.ForeColor = Color.Gray;
            lblDesc.Location = new Point(50, 28);
            lblDesc.AutoSize = false;
            lblDesc.Size = new Size(card.Width - 70, 30);

            // Time
            Label lblTime = new Label();
            lblTime.Text = notif.Time;
            lblTime.Font = new Font("Microsoft Sans Serif", 7.5f);
            lblTime.ForeColor = Color.LightGray;
            lblTime.Location = new Point(50, 58);
            lblTime.AutoSize = true;

            // Chấm xanh chưa đọc
            if (!notif.IsRead)
            {
                Panel dot = new Panel();
                dot.Size = new Size(8, 8);
                dot.Location = new Point(card.Width - 20, 10);
                dot.BackColor = Color.FromArgb(24, 95, 165);
                card.Controls.Add(dot);
            }

            // Click để đánh dấu đã đọc
            card.Click += (s, ev) =>
            {
                notif.IsRead = true;
                card.BackColor = Color.White;
                LoadNotifications();
            };

            card.Controls.Add(lblIcon);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblDesc);
            card.Controls.Add(lblTime);

            return card;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Class thông báo
    public class NotificationItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public string Type { get; set; } // "vaccine", "admin"
        public bool IsRead { get; set; }
    }
}