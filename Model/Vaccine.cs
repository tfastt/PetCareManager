namespace PetCareManager.Model
{
    public class Vaccine
    {
        public int VaccineID { get; set; }
        public string VaccineName { get; set; }
        public string ForSpecies { get; set; }
        public string PreventDisease { get; set; }
        public int RecommendedIntervalMonths { get; set; }
        public string Note { get; set; }
    }
}