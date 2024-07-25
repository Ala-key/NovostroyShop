using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NovostroyShop.Authentication;

namespace NovostroyShop.Services
{
    public class InitialAdminSetupService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public InitialAdminSetupService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string[] roleNames = { "Admin", "User" };
                IdentityResult roleResult;

                foreach (var roleName in roleNames)
                {
                    var roleExist = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                var user = await userManager.FindByEmailAsync("admin@email.com");

                if (user == null)
                {
                    var poweruser = new ApplicationUser
                    {
                        UserName = "Admin",
                        Email = "admin@email.com",
                    };
                    string adminPassword = "Q7&@6d?_rT-A";
                    var createPowerUser = await userManager.CreateAsync(poweruser, adminPassword);
                    if (createPowerUser.Succeeded)
                    {
                        await userManager.AddToRoleAsync(poweruser, "Admin");
                    }
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }

}
