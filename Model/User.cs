namespace PetCareManager.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Note { get; set; }
    }
}
