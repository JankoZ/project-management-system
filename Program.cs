using Microsoft.Extensions.DependencyInjection;
using ProjectManagementSystem.DI;
using ProjectManagementSystem.Enums;
using ProjectManagementSystem.Menus;
using ProjectManagementSystem.Menus.Impl;
using ProjectManagementSystem.Services;

namespace ProjectManagementSystem;

public class Program
{
    public static void Main()
    {
        var serviceCollection = new ServiceCollection();
        DiContainer.ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        serviceProvider.GetRequiredService<IUserService>();
        Run(serviceProvider);
    }

    private static void Run(ServiceProvider serviceProvider)
    {
        var authService = serviceProvider.GetRequiredService<IAuthService>();

        while (true)
        {
            IMenu currentMenu = authService.CurrentUser switch
            {
                null => serviceProvider.GetRequiredService<LoginMenu>(),
                { Role: UserRole.Manager } => serviceProvider.GetRequiredService<ManagerMenu>(),
                _ => serviceProvider.GetRequiredService<EmployeeMenu>()
            };
            
            currentMenu.Display();
        }
    }
}
