using ITeam.Application.Mapper;
using ITeam.Application.Services.Modules;
using ITeam.Application.Services.Products;
using ITeam.DataAccess;
using ITeam.DataAccess.Models;
using ITeam.DataAccess.Repositories.Modules;
using ITeam.DataAccess.Repositories.Products;
using ITeam.Presentation.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ITeam;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("database")));


        builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddScoped<IMapper<ModuleDto, ModuleEntity>, ModuleMapper>();
        builder.Services.AddScoped<IMapper<ProductDto, ProductEntity>, ProductMapper>();

        builder.Services.AddScoped<IModuleService, ModuleService>();
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
