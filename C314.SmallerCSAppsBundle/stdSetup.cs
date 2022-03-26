namespace C314.SmallerCSAppsBundle
{
    internal class stdSetup
    {
        public const string title = "314 smaller C# programs bundle";
        public static void FirstTimeSetup()
        {
            Setup();
            CDictionaries.CommandsInfo.Add("general", "" + stdSetup.title + "\n\nSome small C# programs by 314\n\nAvailable commands:\n1. help\n2. KeyCodes\n\nFor more information about a specific command type \"help <command>\"");
            CDictionaries.CommandsInfo.Add("help", "Displays help about the program (using \"help\") or a given command (using \"help <command>\")");
            CDictionaries.CommandsInfo.Add("KeyCodes", "Runs the KeyCodes program which displays the keycode of the key you pressed in this format:\n<key you pressed> -> <keycode>");
            CDictionaries.CommandsInfo.Add("hmstoms", "Converts Hours, Minutes and Seconds to milliseconds. Input should be seperated with spaces");
            CDictionaries.CommandsWithNoArgs.Add("KeyCodes", Commands.Key_Codes);
            CDictionaries.CommandsWithNoArgs.Add("help", Commands.Help);
            CDictionaries.CommandsWithArgs.Add("help", Commands.HelpArg);
        }
        public static void Setup()
        {
            Console.Title = title;
            Console.ForegroundColor = ConsoleColor.White;
            Console.TreatControlCAsInput = false;
        }
    }
}
