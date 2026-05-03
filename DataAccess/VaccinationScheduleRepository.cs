using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PetCareManager.Model;

namespace PetCareManager.DataAccess
{
    public class VaccinationScheduleService
    {
        private string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=PetCareManagement;Trusted_Connection=True;";

        // GET ALL
        public List<VaccinationSchedule> GetAllSchedules()
        {
            List<VaccinationSchedule> schedules = new List<VaccinationSchedule>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_GetAllVaccinationSchedules", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VaccinationSchedule schedule = new VaccinationSchedule()
                    {
                        ScheduleID = (int)reader["ScheduleID"],
                        PetID = (int)reader["PetID"],
                        VaccineID = (int)reader["VaccineID"],
                        CreatedByUserID = (int)reader["CreatedByUserID"],
                        VaccinationDate = (DateTime)reader["VaccinationDate"],
                        NextVaccinationDate = (DateTime)reader["NextVaccinationDate"],
                        Status = reader["Status"].ToString(),
                        Note = reader["Note"].ToString()
                    };

                    schedules.Add(schedule);
                }
            }

            return schedules;
        }

        // GET BY ID
        public VaccinationSchedule GetScheduleByID(int scheduleId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_GetVaccinationScheduleByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ScheduleID", scheduleId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new VaccinationSchedule()
                    {
                        ScheduleID = (int)reader["ScheduleID"],
                        PetID = (int)reader["PetID"],
                        VaccineID = (int)reader["VaccineID"],
                        CreatedByUserID = (int)reader["CreatedByUserID"],
                        VaccinationDate = (DateTime)reader["VaccinationDate"],
                        NextVaccinationDate = (DateTime)reader["NextVaccinationDate"],
                        Status = reader["Status"].ToString(),
                        Note = reader["Note"].ToString()
                    };
                }
            }

            return null;
        }

        // CREATE SCHEDULE
        public void CreateSchedule(VaccinationSchedule schedule)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_CreateVaccinationSchedule", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PetID", schedule.PetID);
                cmd.Parameters.AddWithValue("@VaccineID", schedule.VaccineID);
                cmd.Parameters.AddWithValue("@CreatedByUserID", schedule.CreatedByUserID);
                cmd.Parameters.AddWithValue("@VaccinationDate", schedule.VaccinationDate);
                cmd.Parameters.AddWithValue("@Status", schedule.Status);
                cmd.Parameters.AddWithValue("@Note", schedule.Note);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // UPDATE SCHEDULE
        public void UpdateSchedule(VaccinationSchedule schedule)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_UpdateVaccinationSchedule", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ScheduleID", schedule.ScheduleID);
                cmd.Parameters.AddWithValue("@VaccinationDate", schedule.VaccinationDate);
                cmd.Parameters.AddWithValue("@Status", schedule.Status);
                cmd.Parameters.AddWithValue("@Note", schedule.Note);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // COMPLETE SCHEDULE
        public void CompleteSchedule(int scheduleId, DateTime completedDate, string note)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_CompleteVaccinationSchedule", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ScheduleID", scheduleId);
                cmd.Parameters.AddWithValue("@CompletedDate", completedDate);
                cmd.Parameters.AddWithValue("@Note", note);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // GET UPCOMING VACCINATIONS
        public List<VaccinationSchedule> GetUpcomingVaccinations()
        {
            List<VaccinationSchedule> schedules = new List<VaccinationSchedule>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_GetUpcomingVaccinations", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VaccinationSchedule schedule = new VaccinationSchedule()
                    {
                        ScheduleID = (int)reader["ScheduleID"],
                        PetID = (int)reader["PetID"],             
                        VaccineID = (int)reader["VaccineID"],      
                        CreatedByUserID = (int)reader["CreatedByUserID"],
                        NextVaccinationDate = (DateTime)reader["NextVaccinationDate"],
                        Status = reader["Status"].ToString()
                    };

                    schedules.Add(schedule);
                }
            }

            return schedules;
        }


    }
}
