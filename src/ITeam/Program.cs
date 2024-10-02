using ITeam.Application.Mapper;
using ITeam.Application.Services.Modules;
using ITeam.Application.Services.Products;
using ITeam.DataAccess;
using ITeam.DataAccess.Models;
using ITeam.DataAccess.Repositories.Modules;
using ITeam.DataAccess.Repositories.Products;
using ITeam.Presentation.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ITeam.Presentation.Middlewares;

namespace ITeam;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("database")));

        builder.Services.AddControllers();

        RepositoryInjection(builder);
        ServiceInjection(builder);
        MappersInjection(builder);

        builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "ITeam API", Version = "v1" }));

        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }

    private static void RepositoryInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
    }

    private static void ServiceInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IModuleService, ModuleService>();
        builder.Services.AddScoped<IProductService, ProductService>();
    }

    private static void MappersInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMapper<ModuleDto, ModuleEntity>, ModuleMapper>();
        builder.Services.AddScoped<IMapper<ProductDto, ProductEntity>, ProductMapper>();
    }
}
