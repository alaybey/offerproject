using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Business.Services;
using Business.MappingProfiles;
using Microsoft.AspNetCore.Hosting;

namespace Business;
public static class BusinessDI { 
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddServices(env);

        services.RegisterAutoMapper();

        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped<IOfferService, OfferService>();
        services.AddScoped<ICountryService, CountryService>();

    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }

}