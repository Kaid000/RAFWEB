using RAFWEB.Domain.Repositories.Users.Interfaces;

namespace RAFWEB.API.Configuration.Extentions
{
    public static class RepositoriesExtention
    {
        public static void AddRepositoreis(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

        }
    }
}
