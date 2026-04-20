using ProjectManagementSystem.Models;
using ProjectManagementSystem.Storage;

namespace ProjectManagementSystem.Services.Impl;

public class LogService : ILogService
{
    private readonly IStorage _storage;

    public LogService(IStorage storage) => _storage = storage;
    
    public void Log(string message)
    {
        var data = _storage.Load();
        data.Logs.Add(new LogEntry { Message = message });
        _storage.Save(data);
    }

    public List<LogEntry> GetLogs() => _storage.Load().Logs.OrderByDescending(l => l.Timestamp).ToList();
}
