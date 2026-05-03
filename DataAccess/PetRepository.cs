using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PetCareManager.Model;

namespace PetCareManager.DataAccess
{
    public class PetService
    {
        private string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=PetCareManagement;Trusted_Connection=True;";

        // ===== GET ALL =====
        public List<Pet> GetAllPets()
        {
            List<Pet> pets = new List<Pet>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllPets", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pet p = new Pet()
                    {
                        PetID = (int)reader["PetID"],
                        PetName = reader["PetName"].ToString(),
                        Species = reader["Species"].ToString(),
                        Breed = reader["Breed"].ToString(),
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Weight = Convert.ToDouble(reader["Weight"]),
                        HealthStatus = reader["HealthStatus"].ToString(),
                        UserID = (int)reader["UserID"],
                        Gender = reader["Gender"].ToString(),
                        Note = reader["Note"].ToString()
                    };

                    pets.Add(p);
                }
            }

            return pets;
        }

        // ===== GET BY ID =====
        public Pet GetPetByID(int petId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPetByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PetID", petId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Pet()
                    {
                        PetID = (int)reader["PetID"],
                        PetName = reader["PetName"].ToString(),
                        Species = reader["Species"].ToString(),
                        Breed = reader["Breed"].ToString(),
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Weight = Convert.ToDouble(reader["Weight"]),
                        HealthStatus = reader["HealthStatus"].ToString(),
                        UserID = (int)reader["UserID"],
                        Gender = reader["Gender"].ToString(),
                        Note = reader["Note"].ToString()
                    };
                }
            }
            return null;
        }

        // ===== ADD =====
        public void AddPet(Pet pet)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddPet", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PetName", pet.PetName);
                cmd.Parameters.AddWithValue("@Species", pet.Species);
                cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                cmd.Parameters.AddWithValue("@DateOfBirth", pet.DateOfBirth);
                cmd.Parameters.AddWithValue("@Weight", pet.Weight);
                cmd.Parameters.AddWithValue("@HealthStatus", pet.HealthStatus);
                cmd.Parameters.AddWithValue("@UserID", pet.UserID);
                cmd.Parameters.AddWithValue("@Gender", pet.Gender);
                cmd.Parameters.AddWithValue("@Note", pet.Note);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ===== UPDATE =====
        public void UpdatePet(Pet pet)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdatePet", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PetID", pet.PetID);
                cmd.Parameters.AddWithValue("@PetName", pet.PetName);
                cmd.Parameters.AddWithValue("@Species", pet.Species);
                cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                cmd.Parameters.AddWithValue("@DateOfBirth", pet.DateOfBirth);
                cmd.Parameters.AddWithValue("@Weight", pet.Weight);
                cmd.Parameters.AddWithValue("@HealthStatus", pet.HealthStatus);
                cmd.Parameters.AddWithValue("@UserID", pet.UserID);
                cmd.Parameters.AddWithValue("@Gender", pet.Gender);
                cmd.Parameters.AddWithValue("@Note", pet.Note);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ===== DELETE =====
        public void DeletePet(int petId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeletePet", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PetID", petId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
