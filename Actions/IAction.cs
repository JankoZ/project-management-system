namespace ProjectManagementSystem.Actions;

public interface IAction
{
    string Description { get; }
    void Execute();
}
