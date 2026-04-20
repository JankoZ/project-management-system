using ProjectManagementSystem.Actions;
using ProjectManagementSystem.Utils;

namespace ProjectManagementSystem.Menus;

public abstract class ActionMenu : IMenu
{
    protected List<IAction> Actions = [];
    protected abstract string Header { get; }
    
    public void Display()
    {
        IoUtils.PrintInfo($"\n--- {Header} ---");
        for (int i = 0; i < Actions.Count; ++i)
            Console.WriteLine($"{i + 1}. {Actions[i].Description}");

        if (!int.TryParse(Console.ReadLine(), out int choice)) return;
        if (choice > 0 && choice <= Actions.Count)
            Actions[choice - 1].Execute();
    }
}
