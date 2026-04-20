using ProjectManagementSystem.Enums;

namespace ProjectManagementSystem.Models;

public class ProjectTask
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ProjectId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid AssignedEmployeeId { get; set; }
    public ProjectTaskStatus Status { get; set; } = ProjectTaskStatus.Todo;
}
