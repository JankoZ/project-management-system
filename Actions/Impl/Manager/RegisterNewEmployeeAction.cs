using ProjectManagementSystem.Services;
using ProjectManagementSystem.Utils;

namespace ProjectManagementSystem.Actions.Impl.Manager;

public class RegisterNewEmployeeAction : IAction
{
    private readonly IUserService _userService;

    public RegisterNewEmployeeAction(IUserService userService) => _userService = userService;
    
    public string Description => "Register new employee";
    
    public void Execute()
    {
        Console.WriteLine();
        string login = IoUtils.ReadNonEmptyInput("Login: ");
        string password = IoUtils.ReadNonEmptyInput("Password: ");
        
        try
        {
            _userService.RegisterEmployee(login, password);
        }
        catch (Exception ex)
        {
            IoUtils.PrintError($"Error: {ex.Message}");
            return;
        }
        
        IoUtils.PrintInfo($"\nEmployee {login} is registered!");
    }
}
