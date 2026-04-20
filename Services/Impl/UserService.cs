using ProjectManagementSystem.Enums;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.Storage;

namespace ProjectManagementSystem.Services.Impl;

public class UserService : IUserService
{
    private readonly IStorage _storage;
    
    public UserService(IStorage storage)
    {
        _storage = storage;
        
        var data = _storage.Load();

        if (data.Users.Count != 0) return;
        
        data.Users.Add(new User { Login = "admin", Password = "admin", Role = UserRole.Manager });
        _storage.Save(data);
    }
    
    public void RegisterEmployee(string login, string password)
    {
        var data = _storage.Load();
        
        if (data.Users.Any(u => u.Login == login))
            throw new Exception("User with the same login already exists.");
        
        data.Users.Add(new User { Login = login, Password = password, Role = UserRole.Employee });
        _storage.Save(data);
    }

    public List<User> GetEmployees() => _storage.Load().Users.Where(u => u.Role == UserRole.Employee).ToList();
}
