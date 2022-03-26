using CommandLine;
using Sharprompt;

namespace C314.SmallerCSAppsBundle
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            stdSetup.FirstTimeSetup();
            Console.WriteLine(stdSetup.title);
            Console.WriteLine();
            while (true)
            {
                try
                {
                    string input = Prompt.Input<string>("CMD");
                    string[] Cargs = input.Split(" ");
                    CommandLine.Parser.Default.ParseArguments<Verbs.hmstoms>(Cargs)
                        .MapResult(
                            (Verbs.hmstoms opts) => CInputHandlers.RunHmstomsAndReturnExitCode(opts),
                            errs => CErrorHandlers.HandleParseError(errs));
                    return 0;
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
