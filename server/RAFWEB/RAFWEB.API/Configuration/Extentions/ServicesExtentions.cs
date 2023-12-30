using RAFWEB.Domain.Services.Interfaces;
using RAFWEB.Domain.Services;

namespace RAFWEB.API.Configuration.Extentions
{
    public static class ServicesExtentions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
