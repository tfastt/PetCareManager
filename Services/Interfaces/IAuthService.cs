using PetCareManager.Model;

namespace PetCareManager.Services.Interfaces
{
    public interface IAuthService
    {
        User Login(string email, string password);
        User Register(string fullName, string email, string password, string confirmPassword);
    }
}
