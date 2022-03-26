using CommandLine;
using C314.SmallerCSAppsBundle.Verbs;

namespace C314.SmallerCSAppsBundle
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            Type[] types = { typeof(hmstoms) };
            stdSetup.FirstTimeSetup();
            Console.WriteLine(stdSetup.title);
            Console.WriteLine();
            Parser.Default.ParseArguments(args, types)
                  .WithParsed(Run)
                  .WithNotParsed(errors => CErrorHandlers.HandleParseError(errors));
            return 0;
        }

        private static void Run(object obj)
        {
            switch (obj)
            {
                case hmstoms h:
                    SingleMethodCommands.Time.HMSToMs(h.Hms);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
