using System;
namespace PetCareManager.Model
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Pet
    {
        public int PetID { get; set; }
        public string PetName { get; set; } 
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public double? Weight { get; set; }
        public string HealthStatus { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public Gender Gender { get; set; }
        public string Note { get; set; }
    }
}
