using System.Text.Json;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Storage.Impl;

public class JsonStorage : IStorage
{
    private readonly string _filePath = "data.json";
    
    public DataContainer Load()
    {
        if (!File.Exists(_filePath)) return new DataContainer();
        
        string json = File.ReadAllText(_filePath);
        
        return JsonSerializer.Deserialize<DataContainer>(json) ?? new DataContainer();
    }

    public void Save(DataContainer data)
    {
        string json = JsonSerializer.Serialize(data,
            new JsonSerializerOptions { WriteIndented = true });
        
        File.WriteAllText(_filePath, json);
    }
}
