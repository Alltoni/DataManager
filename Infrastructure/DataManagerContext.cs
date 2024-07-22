using DataManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DataManager.Infrastructure;

public class DataManagerContext : DbContext
{
    public DbSet<Human> Humans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString: "Server=localhost;Database=DataManagerDb;Trusted_Connection=true;Encrypt=false");
    }
}
