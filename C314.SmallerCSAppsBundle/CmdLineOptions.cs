using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace C314.SmallerCSAppsBundle
{
    internal class CmdLineOptions
    {
        [Option('c', "cmd", Required = false, HelpText = "The command to be run")]
        public string Cmd { get; set; }
    }
}
