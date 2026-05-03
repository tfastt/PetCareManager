using System.Collections.Generic;
using System.Linq;
using PetCareManager.Model;

public class PetRepository : IPetRepository
{
    private readonly AppDbContext _context;

    public PetRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Pet> GetAll()
    {
        return _context.Pets.ToList();
    }

    public List<Pet> GetByUserId(int userId)
    {
        return _context.Pets.Where(p => p.UserID == userId).ToList();
    }

    public Pet GetById(int petId)
    {
        return _context.Pets.FirstOrDefault(p => p.PetID == petId);
    }

    public void Add(Pet pet)
    {
        _context.Pets.Add(pet);
        _context.SaveChanges();
    }

    public void Update(Pet pet)
    {
        _context.Pets.Update(pet);
        _context.SaveChanges();
    }

    public void Delete(int petId)
    {
        var pet = GetById(petId);
        if (pet != null)
        {
            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }
    }
}
