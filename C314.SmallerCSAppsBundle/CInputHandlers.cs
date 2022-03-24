namespace C314.SmallerCSAppsBundle
{
    internal class CInputHandlers
    {
        public static int HandleInput(string? input)
        {
            if (String.IsNullOrEmpty(input)) return -1;
            try
            {
                int res;
                if (input.Split(" ").Length >= 2)
                {
                    string[] vs = input.Split(" ");
                    string arg = String.Join(" ", vs.Skip(1).ToArray());
                    res = CDictionaries.CommandsWithArgs[vs[0]].Invoke(arg);
                    stdSetup.Setup();
                    return res;
                }

                res = CDictionaries.CommandsWithNoArgs[input].Invoke();
                stdSetup.Setup();
                return res;
            }
            catch
            {
                return -1;
            }
        }

        public static void HandleCmdLineInput(CmdLineOptions options)
        {
            if (!String.IsNullOrEmpty(options.Cmd)) HandleInput(options.Cmd);
        }
    }
}
