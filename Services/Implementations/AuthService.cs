using PetCareManager.Model;
using PetCareManager.Services.Interfaces;
using PetCareManager.DataAccess;

namespace PetCareManager.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private UserRepository _userRepository;

        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);

            if (user == null)
                throw new Exception("User not found");

            if (user.PasswordHash != password) // demo: chưa hash
                throw new Exception("Wrong password");

            return user;
        }
    }
}
