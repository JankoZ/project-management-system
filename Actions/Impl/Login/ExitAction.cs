namespace ProjectManagementSystem.Actions.Impl.Login;

public class ExitAction : IAction
{
    public string Description => "Exit";
    
    public void Execute()
    {
        Environment.Exit(0);
    }
}
