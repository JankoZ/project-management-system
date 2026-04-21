using ProjectManagementSystem.Actions;
using ProjectManagementSystem.Actions.Impl.Login;
using ProjectManagementSystem.Actions.Impl.Manager;

namespace ProjectManagementSystem.Menus.Impl;

public class ManagerMenu : ActionMenu
{
    protected override string Header => "Manager Menu";

    public ManagerMenu(IActionFactory actionFactory)
    {
        Actions.Add(actionFactory.Create<CreateNewTaskAction>());
        Actions.Add(actionFactory.Create<ShowAllTasksAction>());
        Actions.Add(actionFactory.Create<ShowProjectTasksAction>());
        Actions.Add(actionFactory.Create<RegisterNewEmployeeAction>());
        Actions.Add(actionFactory.Create<ViewLogsAction>());
        Actions.Add(actionFactory.Create<LogoutAction>());
        Actions.Add(actionFactory.Create<ExitAction>());
    }
}
