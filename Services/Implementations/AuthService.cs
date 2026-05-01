using PetCareManager.Model;
using PetCareManager.Services.Interfaces;

namespace PetCareManager.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private List<User> _users = new List<User>();

        public User Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.UserName == username);

            if (user == null || user.PasswordHash != password)
                throw new Exception("Invalid username or password");

            return user;
        }

        public User Register(User user)
        {
            if (_users.Any(u => u.UserName == user.UserName))
                throw new Exception("User already exists");

            user.UserID = _users.Count + 1;
            user.Role = "Owner";

            _users.Add(user);
            return user;
        }
    }
}
