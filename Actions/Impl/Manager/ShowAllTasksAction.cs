using ProjectManagementSystem.Services;
using ProjectManagementSystem.Utils;

namespace ProjectManagementSystem.Actions.Impl.Manager;

public class ShowAllTasksAction : IAction
{
    private readonly ITaskService _taskService;
    
    public ShowAllTasksAction(ITaskService taskService) =>  _taskService = taskService;
  
    public string Description => "Show all tasks";
    
    public void Execute()
    {
        IoUtils.PrintInfo("\nAll tasks:");
        foreach (var t in _taskService.GetTasks())
            Console.WriteLine($"[{t.Status}]{t.ProjectId}: {t.Title}");
    }
}
