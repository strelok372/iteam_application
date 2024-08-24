using ITeam.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ITeam;

public class Program
{
    public static void Main(string[] args)
    {
        //var builder = WebApplication.CreateBuilder(args);
        //var app = builder.Build();

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();
        app.Run();

        //app.MapGet("/", () => "Hello World!");
        //app.Run();
    }
}
