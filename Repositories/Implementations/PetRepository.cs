using System.Collections.Generic;
using System.Linq;
using PetCareManager.Model;

public class PetRepository : IPetRepository
{
    private List<Pet> _pets = new List<Pet>();

    public List<Pet> GetAll()
    {
        return _pets;
    }

    public List<Pet> GetByUserId(int userId)
    {
        return _pets.Where(p => p.UserID == userId).ToList();
    }

    public Pet GetById(int petId)
    {
        return _pets.FirstOrDefault(p => p.PetID == petId);
    }

    public void Add(Pet pet)
    {
        _pets.Add(pet);
    }

    public void Update(Pet pet)
    {
        var existing = GetById(pet.PetID);
        if (existing == null) return;

        existing.PetName = pet.PetName;
        existing.Species = pet.Species;
        existing.Breed = pet.Breed;
        existing.Weight = pet.Weight;
        existing.HealthStatus = pet.HealthStatus;
    }

    public void Delete(int petId)
    {
        var pet = GetById(petId);
        if (pet != null)
            _pets.Remove(pet);
    }
}
