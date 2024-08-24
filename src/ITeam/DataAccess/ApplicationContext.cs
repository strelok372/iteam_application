using ITeam.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ITeam.DataAccess;

public class ApplicationContext : DbContext
{
    public DbSet<ModuleEntity> Services { get; set; }
    public DbSet<ModuleTypeEntity> ServiceTypes { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
