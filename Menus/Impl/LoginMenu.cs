using ProjectManagementSystem.Actions;
using ProjectManagementSystem.Actions.Impl.Login;

namespace ProjectManagementSystem.Menus.Impl;

public class LoginMenu : ActionMenu
{
    protected override string Header => "Login Menu";
    
    public LoginMenu(IActionFactory actionFactory)
    {
        Actions.Add(actionFactory.Create<LoginAction>());
        Actions.Add(actionFactory.Create<ExitAction>());
    }
}
