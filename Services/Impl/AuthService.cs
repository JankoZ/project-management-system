using ProjectManagementSystem.Models;
using ProjectManagementSystem.Storage;

namespace ProjectManagementSystem.Services.Impl;

public class AuthService : IAuthService
{
    private readonly IStorage _storage;

    public User CurrentUser { get; private set; }

    public AuthService(IStorage storage) => _storage = storage;

    public void Login(string login, string password)
    {
        var data = _storage.Load();
        var user = data.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

        CurrentUser = user ?? throw new Exception("Incorrect login or password.");
    }

    public string Logout()
    {
        string userLogin = CurrentUser.Login;
        CurrentUser = null;
        
        return userLogin;
    }
}
