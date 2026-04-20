using ProjectManagementSystem.Services;
using ProjectManagementSystem.Utils;

namespace ProjectManagementSystem.Actions.Impl.Manager;

public class CreateNewTaskAction : IAction
{
    private readonly IUserService _userService;
    private readonly ITaskService _taskService;

    public CreateNewTaskAction(IUserService userService, ITaskService taskService)
    {
        _userService = userService;
        _taskService = taskService;
    }
    
    public string Description => "Create new task";
    
    public void Execute()
    {
        var employees = _userService.GetEmployees();
        
        if (employees.Count == 0)
        {
            Console.WriteLine("\nNo employees found.");
            return;
        }
        
        Console.WriteLine();
        string projectId = IoUtils.ReadNonEmptyInput("Project ID: ");
        string title = IoUtils.ReadNonEmptyInput("Title: ");
        string description = IoUtils.ReadNonEmptyInput("Description: ");
        
        Console.WriteLine("Select an employee:");
        for (int i = 0; i < employees.Count; ++i)
            Console.WriteLine($"{i + 1}. {employees[i].Login}");
        
        if (int.TryParse(IoUtils.ReadNonEmptyInput(), out int id) && id > 0 && id <= employees.Count)
        {
            _taskService.CreateTask(projectId, title, description, employees[id - 1].Id);
            IoUtils.PrintInfo($"\nTask {projectId}.{title} created.");
        }
    }
}
