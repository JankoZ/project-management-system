using ProjectManagementSystem.Services;
using ProjectManagementSystem.Utils;

namespace ProjectManagementSystem.Actions.Impl.Login;

public class LoginAction : IAction
{
    private readonly IAuthService _authService;
    
    public LoginAction(IAuthService authService) => _authService = authService;

    public string Description => "Log in";
    
    public void Execute()
    {
        Console.WriteLine();
        try
        {
            string login = IoUtils.ReadNonEmptyInput("Login: ");
            string password = IoUtils.ReadNonEmptyInput("Password: ");

            _authService.Login(login, password);
            IoUtils.PrintInfo($"\nWelcome, {login}!");
        }
        catch (Exception ex)
        {
            IoUtils.PrintError($"Error: {ex.Message}");
        }
    }
}
