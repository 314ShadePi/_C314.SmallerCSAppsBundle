// See https://aka.ms/new-console-template for more information
using C314.SmallerCSAppsBundle.GetMCServer;

#region Setup
Console.Title = "314 Smaller C# Programs Bundle";
#endregion

Console.WriteLine("Hello, World!");
// System.Management.Automation Broken
GetMCServer.GetMCServerMain();
Console.ReadKey();
