using ProjectManagementSystem.DTO;
using ProjectManagementSystem.Enums;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Services;

public interface ITaskService
{
    void CreateTask(string projectId, string title, string description, Guid employeeId);
    void UpdateTaskStatus(Guid taskId, ProjectTaskStatus status);
    
    List<ProjectTask> GetTasks();
    List<ProjectTask> GetTasks(Guid employeeId);
    List<ProjectTask> GetTasks(string projectId);
    List<ProjectTask> GetTasks(Guid? userId, TaskQueryOptions options);
}
