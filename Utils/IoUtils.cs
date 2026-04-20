namespace ProjectManagementSystem.Utils;

public static class IoUtils
{
    public static string ReadNonEmptyInput() => ReadNonEmptyInput(String.Empty);
    
    public static string ReadNonEmptyInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(input))
                return input;
        }
    }
    
    public static void PrintError(string prompt)
    {
        ColorPrint(prompt, ConsoleColor.Red);
    }

    public static void PrintInfo(string prompt)
    {
        ColorPrint(prompt, ConsoleColor.Cyan);
    }

    public static void PrintWarning(string prompt)
    {
        ColorPrint(prompt, ConsoleColor.Yellow);
    }

    private static void ColorPrint(string prompt, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(prompt);
        Console.ResetColor();
    }
}