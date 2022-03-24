using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C314.SmallerCSAppsBundle.SingleMethodCommands
{
    public class Time
    {
        public static int HMSToMs(int h, int m, int s) => h * 3600000 + m * 60000 + s * 1000;
    }
}
