using CompanyCatalogue.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<CatalogueDbContext>())
                {
                    try
                    {
                        DataGenerator.GenerateOldWay(context);
                        context.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
