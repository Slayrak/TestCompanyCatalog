using CompanyCatalogue.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CompanyCatalogue.ServicesConfigurations
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogueDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CompanyCatalogue")));

            return services;
        }
    }
}
