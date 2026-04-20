using ProjectManagementSystem.Services;
using ProjectManagementSystem.Utils;

namespace ProjectManagementSystem.Actions.Impl.Login;

public class LogoutAction : IAction
{
    private readonly IAuthService _authService;
    
    public LogoutAction(IAuthService authService) => _authService = authService;
    
    public string Description => "Log out";
    
    public void Execute()
    {
        IoUtils.PrintInfo($"\nUser {_authService.Logout()} has logged out.\n");
    }
}
