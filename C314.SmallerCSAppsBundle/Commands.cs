namespace C314.SmallerCSAppsBundle
{
    internal class Commands
    {
        public static int Key_Codes()
        {
            return ProjOne.KeyCodes.KeyCodesMain();
        }

        public static int Help()
        {
            string? value = "";
            if (CDictionaries.CommandsInfo.TryGetValue("general", out value))
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

        public static int HelpArg(string input)
        {
            string? value = "";
            if (CDictionaries.CommandsInfo.TryGetValue(input, out value))
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

        public static int Hmstoms(int[]? hms)
        {
                Console.WriteLine(SingleMethodCommands.Time.HMSToMs(hms));
                return 0;
        }
    }
}
