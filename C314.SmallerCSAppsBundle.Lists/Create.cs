using C314.jsonTemplates;
using CommandLine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C314.SmallerCSAppsBundle.Lists
{
    [Verb("createlist", HelpText = "Create a new empty list.")]
    public class Create : Common.IVerb
    {
        [Option('n', "name", Required = true, HelpText = "The name of the list.")]
        public string Name { get; set; }

        [Option('i', "item", Required = true, HelpText = "The item to add to the list.")]
        public string Item { get; set; }

        [Option('d', "description", Required = true, HelpText = "The description of the item.")]
        public string Description { get; set; }

        public void HandleInput()
        {
            CList list = new CList
            {
                items = new List<Item>
                {
                    new Item
                    {
                        name = Item,
                        description = Description
                    }
                }
            };
            
            string json = JsonConvert.SerializeObject(list);
            string fileName = $"{Name.Replace(' ', '_')}.json";
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dir = Path.Combine(appdata, "C314.SmallerCSAppsBundle", "lists");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllText(Path.Combine(dir, fileName), json);
        }
    }
}
