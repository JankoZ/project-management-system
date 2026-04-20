using ProjectManagementSystem.Enums;

namespace ProjectManagementSystem.DTO;

public class TaskQueryOptions
{
    public ProjectTaskStatus? FilterStatus { get; set; }
    public string? FilterProjectId { get; set; }
    public string SortBy { get; set; } = "Title";
    public bool IsDescending { get; set; } = false;
}
