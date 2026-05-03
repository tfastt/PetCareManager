using System;
using System.Collections.Generic;
using PetCareManager.Model;

public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;

    public PetService(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public List<Pet> GetPets(User user)
    {
        if (user.Role == "Admin")
            return _petRepository.GetAll();

        return _petRepository.GetByUserId(user.UserID);
    }

    public void AddPet(Pet pet, User user)
    {
        pet.UserID = user.UserID;
        _petRepository.Add(pet);
    }

    public void UpdatePet(Pet pet, User user)
    {
        var existing = _petRepository.GetById(pet.PetID);

        if (existing == null)
            throw new Exception("Pet not found");

        if (user.Role != "Admin" && existing.UserID != user.UserID)
            throw new Exception("No permission");

        _petRepository.Update(pet);
    }

    public void DeletePet(int petId, User user)
    {
        var pet = _petRepository.GetById(petId);

        if (pet == null)
            throw new Exception("Pet not found");

        if (user.Role != "Admin" && pet.UserID != user.UserID)
            throw new Exception("No permission");

        _petRepository.Delete(petId);
    }
}
