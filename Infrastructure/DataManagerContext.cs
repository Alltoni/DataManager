using DataManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DataManager.Infrastructure;

public class DataManagerContext : DbContext
{
    public DbSet<Human> Humans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString: "twój connection string");
    }
}
