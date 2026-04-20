using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Services;

public interface IAuthService
{
    User CurrentUser { get; }
    void Login(string login, string password);
    string Logout();
}
