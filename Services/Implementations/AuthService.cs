using PetCareManager.Models;
using PetCareManager.Services.Interfaces;

namespace PetCareManager.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private List<User> _users = new List<User>();

        public User Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
                throw new Exception("User not found");

            if (user.PasswordHash != password)
                throw new Exception("Wrong password");

            return user;
        }

        public User Register(string username, string password)
        {
            if (_users.Any(u => u.UserName == username))
                throw new Exception("User already exists");

            var user = new User
            {
                UserID = _users.Count + 1,
                UserName = username,
                PasswordHash = password,
                Role = "Owner",
                CreatedDate = DateTime.Now
            };

            _users.Add(user);
            return user;
        }
    }
}
