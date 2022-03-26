using CommandLine;
using C314.SmallerCSAppsBundle.Verbs;

namespace C314.SmallerCSAppsBundle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type[] types = { typeof(hmstoms) };
            _ = Parser.Default.ParseArguments(args, types)
                  .WithParsed(Run)
                  .WithNotParsed(errors => CErrorHandlers.HandleParseError(errors));
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
