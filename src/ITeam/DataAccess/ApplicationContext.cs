using ITeam.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ITeam.DataAccess;

public class ApplicationContext : DbContext
{
    public DbSet<ModuleEntity> Modules { get; set; }
    public DbSet<ModuleTypeEntity> ModuleTypes { get; set; }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductConnectionEntity> ProductConnections { get; set; }
    public DbSet<ProductConnectionTypeEntity> ProductConnectionTypes { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
