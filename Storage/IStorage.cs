using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Storage;

public interface IStorage
{
    DataContainer Load();
    void Save(DataContainer data);
}
