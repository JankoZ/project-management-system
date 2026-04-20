using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Services;

public interface ILogService
{
    void Log(string message);
    List<LogEntry> GetLogs();
}