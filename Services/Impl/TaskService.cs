using ProjectManagementSystem.DTO;
using ProjectManagementSystem.Enums;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.Storage;

namespace ProjectManagementSystem.Services.Impl;

public class TaskService : ITaskService
{
    private readonly IStorage _storage;
    private readonly IAuthService _authService;
    private readonly ILogService _logService;
    
    public TaskService(IStorage storage, IAuthService authService, ILogService logService)
    {
        _storage = storage;
        _authService = authService;
        _logService = logService;
    }
    
    public void CreateTask(string projectId, string title, string description, Guid employeeId)
    {
        var data = _storage.Load();
        
        data.Tasks.Add(new ProjectTask()
        {
            ProjectId = projectId,
            Title = title,
            Description = description,
            AssignedEmployeeId = employeeId
        });
        _storage.Save(data);
    }

    public void UpdateTaskStatus(Guid taskId, ProjectTaskStatus status)
    {
        var data = _storage.Load();
        var task = data.Tasks.FirstOrDefault(t => t.Id == taskId);

        if (task == null) return;

        var oldStatus = task.Status;
        task.Status = status;
        _storage.Save(data);

        string userName = _authService.CurrentUser?.Login ?? "Unknown";
        string message =
            $"{userName} changed status of task [{task.ProjectId}: {task.Title}] from {oldStatus} to {status}";

        _logService.Log(message);
    }

    public List<ProjectTask> GetTasks() => _storage.Load().Tasks;

    public List<ProjectTask> GetTasks(Guid employeeId) => GetTasks(employeeId, new TaskQueryOptions());

    public List<ProjectTask> GetTasks(string projectId) =>
        _storage.Load().Tasks.Where(t => t.ProjectId == projectId).ToList();

    public List<ProjectTask> GetTasks(Guid? employeeId, TaskQueryOptions options)
    {
        var tasks = _storage.Load().Tasks.AsQueryable();

        if (employeeId.HasValue)
            tasks = tasks.Where(t => t.AssignedEmployeeId == employeeId.Value);
        if (options.FilterStatus.HasValue)
            tasks = tasks.Where(t => t.Status == options.FilterStatus.Value);
        if (!string.IsNullOrWhiteSpace(options.FilterProjectId))
            tasks = tasks.Where(t =>
                t.ProjectId.Contains(options.FilterProjectId, StringComparison.OrdinalIgnoreCase));
        
        tasks = options.SortBy.ToLower() switch
        {
            "status" => options.IsDescending ? tasks.OrderByDescending(t => t.Status) :
                tasks.OrderBy(t => t.Status),
            "project" => options.IsDescending ? tasks.OrderByDescending(t => t.ProjectId) :
                tasks.OrderBy(t => t.ProjectId),
            _ => options.IsDescending ? tasks.OrderByDescending(t => t.Title) :
                tasks.OrderBy(t => t.Title)
        };

        return tasks.ToList();
    }
}
