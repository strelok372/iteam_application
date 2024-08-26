using ITeam.Application.Services.Users;
using ITeam.DataAccess;
using ITeam.DataAccess.Repositories;
using ITeam.DataAccess.Repositories.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ITeam;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //builder.Services.AddDbContext<ApplicationContext>(options =>
        //    options.UseNpgsql(builder.Configuration.GetConnectionString("database")));
        builder.Services.AddDbContext<ApplicationContext>(options =>
          options.UseNpgsql(builder.Configuration.GetConnectionString(Environment.GetEnvironmentVariable("DefaultConnection"))));


        builder.Services.AddScoped<IHasher, Hasher>();
        builder.Services.AddScoped<IUsersRepository, UsersRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddControllers();

        RepositoryInjection(builder);

        ServiceInjection(builder);

        builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "ITeam API", Version = "v1" }));

        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();

       
        //builder.Services.AddDbContext<ApplicationContext>(options =>
        //   options.UseNpgsql(builder.Configuration.GetConnectionString(Environment.GetEnvironmentVariable("DefaultConnection"))));

        //var app = builder.Build();
        //app.Run();

        app.MapGet("/", () => "Hello World!");
        app.Run();
    }

    private static void RepositoryInjection(WebApplicationBuilder builder)
    {

    }

    private static void ServiceInjection(WebApplicationBuilder builder)
    {

    }
}
