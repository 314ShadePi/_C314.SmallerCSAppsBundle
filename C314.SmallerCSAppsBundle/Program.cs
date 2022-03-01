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
Setup();
#endregion

Console.WriteLine("Hello, World!");
Console.ReadKey();
KeyCodes.KeyCodesMain();
Setup();
Console.WriteLine("Hello, World!");
Console.ReadKey();
