using CommandLine;
using System.Reflection;

namespace C314.SmallerCSAppsBundle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type[] types = LoadVerbs();
            Parser.Default.ParseArguments(args, types)
                  .WithParsed(Run)
                  .WithNotParsed(HandleErrors);
        }

        private static Type[] LoadVerbs()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();
        }

        private static void HandleErrors(IEnumerable<Error> errors)
        {
            if (errors.IsVersion())
            {
                Console.WriteLine("Version Request");
                return;
            }

            if (errors.IsHelp())
            {
                Console.WriteLine("Help Request");
                return;
            }
            Console.WriteLine("Parser Fail");
        }

        private static void Run(object obj)
        {
            switch (obj)
            {
                case Options o:
                    o.HandleInput();
                    break;
                case Hmstoms o:
                    o.HandleInput();
                    break;
            }
        }
    }
}
