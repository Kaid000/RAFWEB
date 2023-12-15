using Microsoft.AspNetCore.Identity;

namespace RAFWEB.API.Configuration
{
    public class ScopeCreation
    {
        public static async void ConfigureScope(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Teacher", "Student", "Moderator" };

                foreach (var role in roles)
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
