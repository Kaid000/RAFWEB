using Microsoft.EntityFrameworkCore;
using RAFWEB.Core;

namespace RAFWEB.API.Configuration.Extentions
{
    public static class DataBaseExtension

    {

        public static IServiceCollection AddPersistenceInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
