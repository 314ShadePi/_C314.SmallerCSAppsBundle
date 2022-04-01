using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C314.SmallerCSAppsBundle.Lists
{
    [Verb("viewlists", HelpText = "List all your lists or check if a specific one exists.")]
    public class ViewAllLists : Common.IVerb
    {
        [Option('n', "name", Required = false, HelpText = "The name of the list.")]
        public string Name { get; set; }

        public void HandleInput()
        {
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dir = Path.Combine(appdata, "C314.SmallerCSAppsBundle", "lists");
            DirectoryInfo d = new DirectoryInfo(dir);
            if (!String.IsNullOrWhiteSpace(Name))
            {
                string fileName = $"{Name.Replace(' ', '_')}.json";
                var path = Path.Combine(dir, fileName);
                if (File.Exists(path))
                {
                    Console.WriteLine($"List {Name} exists.");
                }
                else
                {
                    Console.WriteLine($"List {Name} does not exist.");
                }
                return;
            }
            FileInfo[] files = d.GetFiles("*.json");
            string[] names = files.Select(x => x.Name.Replace(".json", "").Replace('_', ' ')).ToArray();
            Console.WriteLine("Your lists:");
            foreach (string name in names)
                Console.WriteLine(name);
        }
    }
}
