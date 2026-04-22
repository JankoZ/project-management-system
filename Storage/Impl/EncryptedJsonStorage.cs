using System.Text.Json;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.Utils;

namespace ProjectManagementSystem.Storage.Impl;

public class EncryptedJsonStorage : IStorage
{
    private const string FilePath = "data.protected";

    public DataContainer Load()
    {
        if (!File.Exists(FilePath)) return new DataContainer();

        try
        {
            string encrypted = File.ReadAllText(FilePath);
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
        
        File.WriteAllText(FilePath, EncryptionUtils.Encrypt(json));
    }
}
