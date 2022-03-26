using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C314.SmallerCSAppsBundle.SingleMethodCommands
{
    public class Time
    {
        public static int HMSToMs(int h = 0, int m = 0, int s = 0) => h * 3600000 + m * 60000 + s * 1000;
    }
}
