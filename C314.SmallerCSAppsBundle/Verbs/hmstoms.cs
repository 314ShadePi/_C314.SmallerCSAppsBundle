using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace C314.SmallerCSAppsBundle.Verbs
{
    [Verb("hmstoms", HelpText = "Converts Hours, Minutes and Seconds to milliseconds. Input should be seperated with spaces")]
    internal class hmstoms
    {
        [Value(0, Min = 3, Max = 3)]
        public int[]? Hms { get; set; }
    }
}
