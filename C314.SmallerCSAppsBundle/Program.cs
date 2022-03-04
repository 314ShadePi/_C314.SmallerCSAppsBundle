// See https://aka.ms/new-console-template for more information

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

#region Methods
int HandleInput(string? input)
{
    if (input == null) return -1;
    Console.WriteLine(input);
    return 0;
}
#endregion
Console.WriteLine(title);
Console.WriteLine();
Console.WriteLine("Home~↓");
string? ConsoleInput = Console.ReadLine();
Console.WriteLine();
HandleInput(ConsoleInput);
Console.ReadKey();
