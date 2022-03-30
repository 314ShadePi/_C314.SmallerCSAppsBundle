using CommandLine;
using System.Reflection;

namespace C314.SmallerCSAppsBundle
{
    internal class Program
    {
        private static SingleMethodCommands.Time _time = new SingleMethodCommands.Time();
        static void Main(string[] args)
        {
            Type[] types = LoadVerbs();
#if DEBUG
            foreach (Type t in types)
                Console.WriteLine(t.FullName + "\n");
#endif
            _ = Parser.Default.ParseArguments(args, types)
                  .WithParsed(obj => ((Common.IVerb)obj).HandleInput())
                  .WithNotParsed(HandleErrors);
        }

        private static Type[] LoadVerbs()
        {
            List<Type> types = new List<Type>();
            types.AddRange(Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttribute<VerbAttribute>() != null && t.GetInterfaces().Contains(typeof(Common.IVerb))));
            foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                Assembly assembly = Assembly.Load(assemblyName);
                #if DEBUG
                Console.WriteLine(assemblyName.FullName + "\n");
                #endif
                types.AddRange(assembly.GetTypes().Where(t => t.GetCustomAttribute<VerbAttribute>() != null && t.GetInterfaces().Contains(typeof(Common.IVerb))).ToArray());
            }

            return types.ToArray();
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
