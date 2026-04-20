using ProjectManagementSystem.Enums;

namespace ProjectManagementSystem.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Login { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}
