namespace ProjectManagementSystem.Models;

public class DataContainer
{
    public List<User> Users { get; set; } = [];
    public List<ProjectTask> Tasks { get; set; } = [];
    public List<LogEntry> Logs { get; set; } = [];
}
