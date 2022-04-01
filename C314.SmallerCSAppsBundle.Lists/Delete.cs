using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C314.SmallerCSAppsBundle.Lists
{
    [Verb("deletelist", HelpText = "Delete a list.")]
    public class Delete : Common.IVerb
    {
        [Option('n', "name", Required = true, HelpText = "The name of the list.")]
        public string Name { get; set; }
        
        public void HandleInput()
        {
            string fileName = $"{Name.Replace(' ', '_')}.json";
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dir = Path.Combine(appdata, "C314.SmallerCSAppsBundle", "lists");
            var path = Path.Combine(dir, fileName);
            if (!File.Exists(path))
            {
                Console.WriteLine($"List {Name} does not exist.");
                return;
            }
            File.Delete(path);
            Console.WriteLine($"List {Name} deleted.");
        }
    }
}
