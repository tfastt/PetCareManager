using Microsoft.EntityFrameworkCore;
using PetCareManager.Model;

public class AppDbContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=.;Database=PetCareDB;Trusted_Connection=True;");
    }
}
