using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PetCareManager.Model;

namespace PetCareManager.DataAccess
{
    public class VaccineRepository
    {
        private string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=PetCareManagement;Trusted_Connection=True;";

        public List<Vaccine> GetAllVaccines()
        {
            List<Vaccine> vaccines = new List<Vaccine>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllVaccines", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Vaccine vaccine = new Vaccine()
                    {
                        VaccineID = (int)reader["VaccineID"],
                        VaccineName = reader["VaccineName"].ToString(),
                        ForSpecies = reader["ForSpecies"].ToString(),
                        PreventDisease = reader["PreventDisease"].ToString(),
                        RecommendedIntervalMonths = (int)reader["RecommendedIntervalMonths"],
                        Note = reader["Note"].ToString()
                    };

                    vaccines.Add(vaccine);
                }
            }

            return vaccines;
        }

        public Vaccine GetVaccineByID(int vaccineId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetVaccineByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VaccineID", vaccineId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Vaccine()
                    {
                        VaccineID = (int)reader["VaccineID"],
                        VaccineName = reader["VaccineName"].ToString(),
                        ForSpecies = reader["ForSpecies"].ToString(),
                        PreventDisease = reader["PreventDisease"].ToString(),
                        RecommendedIntervalMonths = (int)reader["RecommendedIntervalMonths"],
                        Note = reader["Note"].ToString()
                    };
                }
            }

            return null;
        }

        public void AddVaccine(Vaccine vaccine)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddVaccine", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VaccineName", vaccine.VaccineName);
                cmd.Parameters.AddWithValue("@ForSpecies", vaccine.ForSpecies);
                cmd.Parameters.AddWithValue("@PreventDisease", vaccine.PreventDisease);
                cmd.Parameters.AddWithValue("@RecommendedIntervalMonths", vaccine.RecommendedIntervalMonths);
                cmd.Parameters.AddWithValue("@Note", vaccine.Note);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateVaccine(Vaccine vaccine)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateVaccine", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VaccineID", vaccine.VaccineID);
                cmd.Parameters.AddWithValue("@VaccineName", vaccine.VaccineName);
                cmd.Parameters.AddWithValue("@ForSpecies", vaccine.ForSpecies);
                cmd.Parameters.AddWithValue("@PreventDisease", vaccine.PreventDisease);
                cmd.Parameters.AddWithValue("@RecommendedIntervalMonths", vaccine.RecommendedIntervalMonths);
                cmd.Parameters.AddWithValue("@Note", vaccine.Note);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteVaccine(int vaccineId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteVaccine", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VaccineID", vaccineId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
