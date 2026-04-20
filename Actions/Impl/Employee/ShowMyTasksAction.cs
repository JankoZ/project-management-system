using ProjectManagementSystem.DTO;
using ProjectManagementSystem.Enums;
using ProjectManagementSystem.Services;
using ProjectManagementSystem.Utils;

namespace ProjectManagementSystem.Actions.Impl.Employee;

public class ShowMyTasksAction : IAction
{
    private readonly IAuthService _authService;
    private readonly ITaskService _taskService;

    public ShowMyTasksAction(IAuthService authService, ITaskService taskService)
    {
        _authService = authService;
        _taskService = taskService;
    }
    
    public string Description => "Show my tasks";
    
    public void Execute()
    {
        var options = new TaskQueryOptions();
        
        IoUtils.PrintInfo("\n--- Filter & Sort Options ---");
        Console.WriteLine("1. Filter by Status");
        Console.WriteLine("2. Sort by Project ID");
        Console.WriteLine("3. Sort by Status");
        Console.WriteLine("Any other key - Skip and show all");
        
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                var statuses = Enum.GetValues<ProjectTaskStatus>();
                IoUtils.PrintInfo("\nStatuses:");
                for (int i = 0; i < statuses.Length; ++i)
                    Console.WriteLine($"{i + 1}. {statuses[i]}");
                if (int.TryParse(IoUtils.ReadNonEmptyInput(), out int sId) && sId > 0 && sId <= statuses.Length)
                    options.FilterStatus = statuses[sId - 1];
                break;
            case "2":
                options.SortBy = "project";
                break;
            case "3":
                options.SortBy = "status";
                break;
        }

        var tasks = _taskService.GetTasks(_authService.CurrentUser.Id, options);
        
        IoUtils.PrintInfo("\n--- Task List ---");
        if (tasks.Count == 0)
            IoUtils.PrintWarning("No tasks found matching criteria.");

        foreach (var t in tasks)
            Console.WriteLine($"[{t.Status}] {t.ProjectId} | {t.Title}");
    }
}
