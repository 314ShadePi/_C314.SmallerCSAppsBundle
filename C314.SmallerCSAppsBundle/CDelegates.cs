using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C314.SmallerCSAppsBundle
{
    internal class CDelegates
    {
        public delegate int CmdWithNoArgs();
        public delegate int CmdWithStringArgs(string arg);
    }
}
