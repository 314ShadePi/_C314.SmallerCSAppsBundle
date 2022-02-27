using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace C314.SmallerCSAppsBundle.GetMCServer
{
    public class GetMCServer
    {
        public static void GetMCServerMain()
        {
            Console.WriteLine("GetMCServer");
            PowerShell ps = PowerShell.Create();
            ps.AddScript(@"D:\C314.SmallerCSAppsBundle\C314.SmallerCSAppsBundle.GetMCServer\get_a_normal_minecraft_server_easily-BitsTransfer.ps1");
            //ps.AddCommand("Get-Process");
            ps.Invoke();
        }
    }
}
