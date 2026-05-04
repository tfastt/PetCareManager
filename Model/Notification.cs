using System;
namespace PetCareManager.Model
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public int UserID { get; set; }
        public int PetID { get; set; }
        public int ScheduleID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string NotificationType { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; }
    }
}
