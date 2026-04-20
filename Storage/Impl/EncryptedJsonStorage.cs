using System.Text.Json;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.Utils;

namespace ProjectManagementSystem.Storage.Impl;

public class EncryptedJsonStorage : IStorage
{
    private readonly string _filePath = "data.protected";
    
    public DataContainer Load()
    {
        if (!File.Exists(_filePath)) return new DataContainer();

        try
        {
            string encrypted = File.ReadAllText(_filePath);
            string json = EncryptionUtils.Decrypt(encrypted);
            return JsonSerializer.Deserialize<DataContainer>(json) ?? new DataContainer();
        }
        catch (Exception)
        {
            return new DataContainer();
        }
    }

    public void Save(DataContainer data)
    {
        string json = JsonSerializer.Serialize(data);
        
        File.WriteAllText(_filePath, EncryptionUtils.Encrypt(json));
    }
}
