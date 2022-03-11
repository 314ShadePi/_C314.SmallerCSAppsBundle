using CommandLine;
using Sharprompt;

namespace C314.SmallerCSAppsBundle
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            stdSetup.FirstTimeSetup();

            if (args.Length > 0)
            {
                CommandLine.Parser.Default.ParseArguments<CmdLineOptions>(args)
                .WithParsed(CInputHandlers.HandleCmdLineInput)
                .WithNotParsed(CErrorHandlers.HandleParseError);

                return 0;
            }

            Console.WriteLine(stdSetup.title);
            Console.WriteLine();


            while (true)
            {
                try
                {
                    int res = CInputHandlers.HandleInput(Prompt.Input<string>("CMD"));
                    Console.WriteLine(res);
                    if (res == -3) return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    int res = CInputHandlers.HandleInput(Console.ReadLine());
                    Console.WriteLine(res);
                    if (res == -3) return 0;
                }
            }
        }
    }
}
