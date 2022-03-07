// See https://aka.ms/new-console-template for more information

#region Usings
using C314.SmallerCSAppsBundle.ProjOne;
using System.Linq;
#endregion

#region Setup
const string title = "314 smaller C# programs bundle";
Dictionary<string, string> CommandsInfo = new Dictionary<string, string>();
CommandsInfo.Add("general", "" + title + "\n\nSome small C# programs by 314\n\nAvailable commands:\n1. help\n2. KeyCodes\n\nFor more information about a specific command type \"help <command>\"");
CommandsInfo.Add("help", "Displays help about the program (using \"help\") or a given command (using \"help <command>\")");
CommandsInfo.Add("KeyCodes", "Runs the KeyCodes program which displays the keycode of the key you pressed in this format:\n<key you pressed> -> <keycode>");

static void Setup()
{
    Console.Title = title;
    Console.ForegroundColor = ConsoleColor.White;
    Console.TreatControlCAsInput = false;
}
Setup();
#endregion

#region Methods
int HandleInput(string? input)
{
    if (input == null || input == "") return -1;
    string[] vs = input.Split(" ");
    switch (vs[0])
    {
        case "KeyCodes": 
            int res = Key_Codes();
            Setup();
            return res;
        case "help":
            if (vs.Length > 1) return HelpArg(vs[1]);
            return Help();
        case "Exit": return -3;
        default: 
            Setup();
            return -1;
    }
}

int HandleCmdLineInput(string[] input)
{
    /*switch (input[0])
    {
        case "-cmd":
            return HandleInput(String.Join(" ", input.Skip(1).ToArray()));
        case "-cmd"
    }*/

    return 0;
}
#endregion

#region Commands
int Key_Codes()
{
    return KeyCodes.KeyCodesMain();
}

int Help()
{
    string? value = "";
    if (CommandsInfo.TryGetValue("general", out value))
    {
        Console.WriteLine(value);
        return 0;
    }
    else
    {
        Console.WriteLine("Command \"help\" is not found.");
        return -1;
    }
}

int HelpArg(string input)
{
    string? value = "";
    if (CommandsInfo.TryGetValue(input, out value))
    {
        Console.WriteLine(value);
        return 0;
    }
    else
    {
        Console.WriteLine("Command \"{0}\" is not found.", input);
        return -1;
    }
}
#endregion

if (args.Length > 0)
{
    int res = HandleCmdLineInput(args);
    Console.WriteLine(res);
    return res;
}

Console.WriteLine(title);
Console.WriteLine();


while (true)
{
    Console.Write("Home>");
    string? ConsoleInput = Console.ReadLine();
    int res = HandleInput(ConsoleInput);
    Console.WriteLine(res);
    if (res == -3) return 0;
}
