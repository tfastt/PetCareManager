using System;
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
                return null;
            if (user.PasswordHash != password)
                return null;

            return user;
        }
        public User Register(string fullName, string email, string password, string confirmPassword)
        {
            if (password != confirmPassword)
                return null;

            var existingUser = _userRepository.GetUserByEmail(email);
            if (existingUser != null)
                return null;

            User newUser = new User()
            {
                UserName = fullName,
                Email = email,
                PasswordHash = password, 
                Role = "Owner",
                Phone = "",
                Address = "",
                Note = ""
            };

            _userRepository.AddUser(newUser);

            return newUser;
        }
    }
}
