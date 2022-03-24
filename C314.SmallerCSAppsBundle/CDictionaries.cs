namespace C314.SmallerCSAppsBundle
{
    internal class CDictionaries
    {
        public static Dictionary<string, string> CommandsInfo = new Dictionary<string, string>();
        public static Dictionary<string, CDelegates.CmdWithNoArgs> CommandsWithNoArgs = new Dictionary<string, CDelegates.CmdWithNoArgs>();
        public static Dictionary<string, CDelegates.CmdWithStringArgs> CommandsWithArgs = new Dictionary<string, CDelegates.CmdWithStringArgs>();
    }
}
