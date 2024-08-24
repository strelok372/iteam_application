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

        public DbSet<User> Users;
        public DbSet<UserType> UserTypes;
        public DbSet<UserStatus> UserStatuses;
        public DbSet<OperationUsers> OperationUsers;
        public DbSet<OperationType> OperationTypes;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserType)
                .WithMany(ut => ut.Users)
                .HasForeignKey(u => u.UserTypeId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserStatus)
                .WithMany(us => us.Users)
                .HasForeignKey(u => u.UserStatusId);

            modelBuilder.Entity<OperationUsers>()
                .HasOne(o => o.User)
                .WithMany(u => u.Operations)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OperationUsers>()
                .HasOne(o => o.OperationType)
                .WithMany(ot => ot.Operations)
                .HasForeignKey(o => o.OperationTypeId);

            //modelBuilder.Entity<User>()
            //    .HasIndex(u => u.Email)
            //    .IsUnique();
      
            // Вызов метода для предзаполнения данных из JSON
            LoadAndSeedJsonData<UserType>(modelBuilder, "DataAccess/Data/userTypes.json");
            LoadAndSeedJsonData<UserStatus>(modelBuilder, "DataAccess/Data/userStatuses.json");
            LoadAndSeedJsonData<OperationType>(modelBuilder, "DataAccess/Data/operationTypes.json");
        }

        private void LoadAndSeedJsonData<T>(ModelBuilder modelBuilder, string filePath) where T : class
        {
            // Чтение содержимого файла
            var json = File.ReadAllText(filePath);
            // Десериализация данных в список объектов
            var data = JsonSerializer.Deserialize<List<T>>(json);
            // Предзаполнение данных
            modelBuilder.Entity<T>().HasData(data);
        }
    }

}
