using ProjectManagementSystem.Services;
using ProjectManagementSystem.Utils;

namespace ProjectManagementSystem.Actions.Impl.Manager;

public class ViewLogsAction : IAction
{
    private readonly ILogService _logService;
    
    public ViewLogsAction(ILogService logService) => _logService = logService;
    
    public string Description => "View logs";
    
    public void Execute()
    {
        var logs = _logService.GetLogs();
        
        IoUtils.PrintInfo("\n--- Logs ---");
        
        if (logs.Count == 0)
            IoUtils.PrintWarning("No logs found.");
        
        foreach (var log in logs)
            Console.WriteLine($"[{log.Timestamp:yyyy-MM-dd HH:mm:ss}] - {log.Message}");
    }
}
