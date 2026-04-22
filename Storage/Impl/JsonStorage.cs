using System.Text.Json;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Storage.Impl;

public class JsonStorage : IStorage
{
    private const string FilePath = "data.json";

    public DataContainer Load()
    {
        if (!File.Exists(FilePath)) return new DataContainer();
        
        string json = File.ReadAllText(FilePath);
        
        return JsonSerializer.Deserialize<DataContainer>(json) ?? new DataContainer();
    }

    public void Save(DataContainer data)
    {
        string json = JsonSerializer.Serialize(data,
            new JsonSerializerOptions { WriteIndented = true });
        
        File.WriteAllText(FilePath, json);
    }
}
