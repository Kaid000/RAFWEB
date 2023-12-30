using AutoMapper;
using RAFWEB.Domain.Services.Mapping;

namespace RAFWEB.API.Configuration.Extentions
{
    public static class AutoMapperExtention
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());

            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
