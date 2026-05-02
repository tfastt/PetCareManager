using System.Collections.Generic;
using PetCareManager.Model;

public interface IPetRepository
{
    List<Pet> GetAll();
    List<Pet> GetByUserId(int userId);
    Pet GetById(int petId);

    void Add(Pet pet);
    void Update(Pet pet);
    void Delete(int petId);
}
