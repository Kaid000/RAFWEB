using Microsoft.EntityFrameworkCore;
using RAFWEB.Core;

namespace RAFWEB.API.Configuration.Extensions
{
    public static class DataBaseExtension
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services)
        => services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer());
    }
}
