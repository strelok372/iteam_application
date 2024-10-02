using ITeam.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace ITeam.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserTypeEntity> UserTypes { get; set; }
        public DbSet<UserStatusEntity> UserStatuses { get; set; }
        public DbSet<OperationUsersEntity> OperationUsers { get; set; }
        public DbSet<OperationTypeEntity> OperationTypes { get; set; }
        public DbSet<UserPurchaseEntity> UserPurchases { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.UserType)
                .WithMany(ut => ut.Users)
                .HasForeignKey(u => u.UserTypeId);

            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.UserStatus)
                .WithMany(us => us.Users)
                .HasForeignKey(u => u.UserStatusId);

            modelBuilder.Entity<OperationUsersEntity>()
                .HasOne(o => o.User)
                .WithMany(u => u.Operations)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OperationUsersEntity>()
                .HasOne(o => o.OperationType)
                .WithMany(ot => ot.Operations)
                .HasForeignKey(o => o.OperationTypeId);

            //modelBuilder.Entity<User>()
            //    .HasIndex(u => u.Email)
            //    .IsUnique();
      
            // Вызов метода для предзаполнения данных из JSON
            LoadAndSeedJsonData<UserTypeEntity>(modelBuilder, "DataAccess/Data/userTypes.json");
            LoadAndSeedJsonData<UserStatusEntity>(modelBuilder, "DataAccess/Data/userStatuses.json");
            LoadAndSeedJsonData<OperationTypeEntity>(modelBuilder, "DataAccess/Data/operationTypes.json");
        }

        private void LoadAndSeedJsonData<T>(ModelBuilder modelBuilder, string filePath) where T : class
        {
            var json = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<List<T>>(json);
            modelBuilder.Entity<T>().HasData(data);
        }
    }

}
