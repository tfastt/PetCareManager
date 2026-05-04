using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PetCareManager.Model;

namespace PetCareManager.DataAccess
{
    public class NotificationRepository
    {
        private string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=PetCareManagement;Trusted_Connection=True;";

        // ===== GET ALL =====
        public List<Notification> GetAllNotifications()
        {
            List<Notification> list = new List<Notification>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_GetAllNotifications", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Notification
                    {
                        NotificationID = (int)reader["NotificationID"],
                        UserID = (int)reader["UserID"],
                        PetID = (int)reader["PetID"],
                        ScheduleID = (int)reader["ScheduleID"],
                        Title = reader["Title"].ToString(),
                        Message = reader["Message"].ToString(),
                        NotificationType = reader["NotificationType"].ToString(),
                        NotificationDate = (DateTime)reader["NotificationDate"],
                        IsRead = (bool)reader["IsRead"]
                    });
                }
            }

            return list;
        }

        // ===== GET BY USER =====
        public List<Notification> GetNotificationsByUserID(int userId)
        {
            List<Notification> list = new List<Notification>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_GetNotificationsByUserID", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Notification
                    {
                        NotificationID = (int)reader["NotificationID"],
                        UserID = (int)reader["UserID"],
                        PetID = (int)reader["PetID"],
                        ScheduleID = (int)reader["ScheduleID"],
                        Title = reader["Title"].ToString(),
                        Message = reader["Message"].ToString(),
                        NotificationType = reader["NotificationType"].ToString(),
                        NotificationDate = (DateTime)reader["NotificationDate"],
                        IsRead = (bool)reader["IsRead"]
                    });
                }
            }

            return list;
        }

        // ===== MARK AS READ =====
        public void MarkAsRead(int notificationId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_MarkNotificationAsRead", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NotificationID", notificationId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ===== DELETE =====
        public void DeleteNotification(int notificationId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_DeleteNotification", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NotificationID", notificationId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
