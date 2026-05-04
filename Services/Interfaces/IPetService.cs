using System.Collections.Generic;
using PetCareManager.Model;
namespace PetCareManager.Services.Interfaces
{
    public interface IPetService
    {
        List<Pet> GetPets(User user);
        void AddPet(Pet pet, User user);
        void UpdatePet(Pet pet, User user);
        void DeletePet(int petId, User user);
    }
}