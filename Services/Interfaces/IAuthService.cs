using PetCareManager.Models;
using PetCareManager.DTOs;

namespace PetCareManager.Services.Interfaces
{
    public interface IAuthService
    {
        User Login(string username, string password);
        User Register(User user);
    }
}
