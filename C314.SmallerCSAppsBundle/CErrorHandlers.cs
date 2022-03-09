using CommandLine;

namespace C314.SmallerCSAppsBundle
{
    internal class CErrorHandlers
    {
        public static void HandleParseError(IEnumerable<Error> errs)
        {
            if (errs.IsVersion())
            {
                Console.WriteLine("Version Request");
                return;
            }

            if (errs.IsHelp())
            {
                Console.WriteLine("Help Request");
                return;
            }
            Console.WriteLine("Parser Fail");
        }
    }
}
