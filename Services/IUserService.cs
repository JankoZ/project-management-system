using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Services;

public interface IUserService
{
    void RegisterEmployee(string login, string password);
    List<User> GetEmployees();
}
