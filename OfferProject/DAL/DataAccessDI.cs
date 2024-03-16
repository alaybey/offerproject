namespace DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DAL.Persistence;
using DAL.Repositories;
using Core.Entities;
using Dal.Repositories;

public static class DataAccessDI
{

    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        services.AddIdentity();

        services.AddRepositories();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services) {
        services.AddScoped<IOfferRepository, OfferRepository>();
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IModeRepository, ModeRepository>();
        services.AddScoped<IPackageTypeRepository, PackageTypeRepository>();
     }

    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {

        DatabaseConfiguration? databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>();
        
        services.AddDbContext<DatabaseContext>(options =>
                options.UseMySQL(databaseConfig != null ? databaseConfig.ConnectionString : "server=mysqldb;database=tempdb;user=root;password=my-secret-pw;sslmode=Required",
                    opt => opt.MigrationsAssembly("API")));
    }
    private static void AddIdentity(this IServiceCollection services) { }
}
public class DatabaseConfiguration
{
    public bool UseInMemoryDatabase { get; set; }

    public required string ConnectionString { get; set; }
}