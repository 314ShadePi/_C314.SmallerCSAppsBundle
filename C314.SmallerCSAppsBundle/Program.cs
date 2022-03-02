// See https://aka.ms/new-console-template for more information
// using C314.SmallerCSAppsBundle.GetMCServer;
// System.Management.Automation Broken
// GetMCServer.GetMCServerMain();

#region Usings
using C314.SmallerCSAppsBundle.ProjOne;
#endregion

#region Setup
const string title = "314 Smaller C# Programs Bundle";

static void Setup()
{
    Console.Title = title;
    Console.ForegroundColor = ConsoleColor.White;
    Console.TreatControlCAsInput = true;
}
Start:
Setup();
#endregion

Console.WriteLine("Please choose what program you want to run:");
Console.WriteLine("<Key To Press> -> <Project That Will Be Launched>");
Console.WriteLine("Escape -> Quit");
Console.WriteLine("1 -> Key Codes");
ConsoleKeyInfo ChosenProject = Console.ReadKey();

switch (ChosenProject.Key.ToString())
{
    case "D1":
        Console.WriteLine("\nProgram chosen: \"Key Codes\", press any key to confirm or \"Escape\" to cancel");
        ConsoleKeyInfo Confirm = Console.ReadKey();
        Console.WriteLine();
        if (Confirm.Key.ToString() == "Escape") goto Start;
        KeyCodes.KeyCodesMain();
        goto Start;
    case "Escape":
        return 0;
    default:
        goto Start;
}
