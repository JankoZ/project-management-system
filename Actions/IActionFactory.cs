namespace ProjectManagementSystem.Actions;

public interface IActionFactory
{
    T Create<T>() where T: class, IAction;
}
