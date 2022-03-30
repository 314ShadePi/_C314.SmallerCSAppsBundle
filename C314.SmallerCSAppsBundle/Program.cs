using CommandLine;
using System.Reflection;

namespace C314.SmallerCSAppsBundle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type[] types = LoadVerbs();
            _ = Parser.Default.ParseArguments(args, types)
                  .WithParsed(obj => ((IVerb)obj).HandleInput())
                  .WithNotParsed(HandleErrors);
        }

        private static Type[] LoadVerbs()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttribute<VerbAttribute>() != null && t.GetInterfaces().Contains(typeof(IVerb))).ToArray();
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

            foreach (var error in errors)
            {
                Console.WriteLine(error.ToString());
            }
        }
    }
}
