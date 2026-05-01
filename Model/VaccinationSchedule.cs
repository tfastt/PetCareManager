namespace PetCareManager.Models
{
    public class VaccinationSchedule
    {
        public int ScheduleID { get; set; }
        public int PetID { get; set; }
        public int VaccineID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime? NextVaccinationDate { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }
}
