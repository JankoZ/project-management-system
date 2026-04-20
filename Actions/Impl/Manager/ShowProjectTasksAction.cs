using ProjectManagementSystem.Services;
using ProjectManagementSystem.Utils;

namespace ProjectManagementSystem.Actions.Impl.Manager;

public class ShowProjectTasksAction : IAction
{
    private readonly ITaskService _taskService;
    
    public ShowProjectTasksAction(ITaskService taskService) =>  _taskService = taskService;
    
    public string Description => "Show project tasks";
    
    public void Execute()
    {
        string projectId = IoUtils.ReadNonEmptyInput("\nEnter project ID: ");
        var tasks = _taskService.GetTasks(projectId);

        if (tasks.Count == 0)
        {
            IoUtils.PrintWarning("\nThere are no tasks for this project.");
            return;
        }
        
        IoUtils.PrintInfo("\nAll project tasks:");
        foreach (var t in tasks)
            Console.WriteLine($"[{t.Status}]{t.ProjectId}: {t.Title}");
    }
}
