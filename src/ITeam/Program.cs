namespace ITeam;

public class Program
{
    public static void Main(string[] args)
    {
        //var builder = WebApplication.CreateBuilder(args);
        //var app = builder.Build();

        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<ApplicationContext>(options =>
       options.UseNpgsql(builder.Configuration.GetConnectionString("database")));

        builder.Services.AddControllers();

        RepositoryInjection(builder);

        ServiceInjection(builder);

        builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "ITeam API", Version = "v1" }));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDbContext<ApplicationContext>(options =>
           options.UseNpgsql(builder.Configuration.GetConnectionString(Environment.GetEnvironmentVariable("DefaultConnection"))));

        var app = builder.Build();
        app.Run();

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
