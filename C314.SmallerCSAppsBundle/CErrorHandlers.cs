using CommandLine;

namespace C314.SmallerCSAppsBundle
{
    internal class CErrorHandlers
    {
        public static int HandleParseError(IEnumerable<Error> errs)
        {
            if (errs.IsVersion())
            {
                Console.WriteLine("Version Request");
                return 0;
            }

            if (errs.IsHelp())
            {
                Console.WriteLine("Help Request");
                return 0;
            }
            Console.WriteLine("Parser Fail");
            return -1;
        }
    }
}
