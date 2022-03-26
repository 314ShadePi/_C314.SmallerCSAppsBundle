using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C314.SmallerCSAppsBundle.SingleMethodCommands
{
    public class Time
    {
        public static int HMSToMs(int[] hms) => hms[0] * 3600000 + hms[1] * 60000 + hms[2] * 1000;
    }
}
