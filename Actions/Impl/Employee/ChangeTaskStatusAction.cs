using ProjectManagementSystem.Enums;
using ProjectManagementSystem.Services;
using ProjectManagementSystem.Utils;

namespace ProjectManagementSystem.Actions.Impl.Employee;

public class ChangeTaskStatusAction : IAction
{
    private readonly IAuthService _authService;
    private readonly ITaskService _taskService;

    public ChangeTaskStatusAction(IAuthService authService, ITaskService taskService)
    {
        _authService = authService;
        _taskService = taskService;
    }
    
    public string Description => "Change task status";
    
    public void Execute()
    {
        var tasks =  _taskService.GetTasks(_authService.CurrentUser.Id);

        if (tasks.Count == 0)
        {
            IoUtils.PrintWarning("\nYou have no tasks assigned.");
            return;
        }
                
        IoUtils.PrintInfo("\nSelect the task number to change:");
        for (int i = 0; i < tasks.Count; ++i)
            Console.WriteLine($"{i + 1}. {tasks[i].Title} ({tasks[i].Status})");

        if (int.TryParse(IoUtils.ReadNonEmptyInput(), out int tId) && tId > 0 && tId <= tasks.Count)
        {
            IoUtils.PrintInfo("\nSelect status:");
            var enums = Enum.GetValues<ProjectTaskStatus>();
            for (int i = 0; i < enums.Length; ++i)
                Console.WriteLine($"{i + 1}. {enums[i]}");

            if (int.TryParse(IoUtils.ReadNonEmptyInput(), out int sId) && sId > 0 && sId <= enums.Length)
            {
                _taskService.UpdateTaskStatus(tasks[tId - 1].Id, (ProjectTaskStatus)(sId - 1));
                IoUtils.PrintInfo("\nStatus updated.");
            }
        }
    }
}
