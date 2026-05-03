using PetCareManager.Model;

namespace PetCareManager.Services.Interfaces
{
    public interface IAuthService
    {
        User Login(string username, string password);
        User Register(string username, string password);
    }
}
