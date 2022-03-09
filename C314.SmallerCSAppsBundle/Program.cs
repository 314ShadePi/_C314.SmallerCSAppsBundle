using C314.SmallerCSAppsBundle;
using CommandLine;
using Sharprompt;

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
    int res = CInputHandlers.HandleInput(Prompt.Input<string>("CMD"));
    Console.WriteLine(res);
    if (res == -3) return 0;
}
