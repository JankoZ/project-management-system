using ProjectManagementSystem.Actions;
using ProjectManagementSystem.Actions.Impl.Employee;
using ProjectManagementSystem.Actions.Impl.Login;

namespace ProjectManagementSystem.Menus.Impl;

public class EmployeeMenu : ActionMenu
{
    protected override string Header => "Employee Menu";

    public EmployeeMenu(IActionFactory actionFactory)
    {
        Actions.Add(actionFactory.Create<ShowMyTasksAction>());
        Actions.Add(actionFactory.Create<ChangeTaskStatusAction>());
        Actions.Add(actionFactory.Create<LogoutAction>());
    }
}
