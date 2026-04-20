using Microsoft.Extensions.DependencyInjection;
using ProjectManagementSystem.Actions;
using ProjectManagementSystem.Actions.Impl.Employee;
using ProjectManagementSystem.Actions.Impl.Login;
using ProjectManagementSystem.Actions.Impl.Manager;
using ProjectManagementSystem.Menus.Impl;
using ProjectManagementSystem.Services;
using ProjectManagementSystem.Services.Impl;
using ProjectManagementSystem.Storage;
using ProjectManagementSystem.Storage.Impl;

namespace ProjectManagementSystem.DI;

public static class DiContainer
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IStorage, JsonStorage>();

        services.AddSingleton<IAuthService, AuthService>();
        services.AddSingleton<ILogService, LogService>();
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<ITaskService, TaskService>();

        services.AddSingleton<IActionFactory, ActionFactory>();
        
        services.AddSingleton<LoginMenu>();
        services.AddSingleton<ManagerMenu>();
        services.AddSingleton<EmployeeMenu>();
        
        services.AddSingleton<LoginAction>();
        services.AddSingleton<LogoutAction>();
        services.AddSingleton<ExitAction>();
        
        services.AddSingleton<CreateNewTaskAction>();
        services.AddSingleton<RegisterNewEmployeeAction>();
        services.AddSingleton<ShowAllTasksAction>();
        services.AddSingleton<ShowProjectTasksAction>();
        services.AddSingleton<ViewLogsAction>();
        
        services.AddSingleton<ChangeTaskStatusAction>();
        services.AddSingleton<ShowMyTasksAction>();
    }
}
