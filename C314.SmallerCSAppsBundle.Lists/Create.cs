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

        [Option('b', "board", Required = false, HelpText = "The board to add the item to.")]
        public string Board { get; set; }

        [Option('e', "boarddescription", Required = false, HelpText = "The description of the board.")]
        public string BoardDescription { get; set; }

        [Option('a', "advanced", Required = false, HelpText = "Advanced mode.")]
        public bool Adcvanced { get; set; }

        public void HandleInput()
        {
            if (Adcvanced)
            {
                CAList alist = new CAList
                {
                    boards = new List<Board>
                    {
                        new Board
                        {
                            name = Board,
                            description = BoardDescription,
                            items = new List<Item>
                            {
                                new Item
                                {
                                    name = Item,
                                    description = Description
                                }
                            }
                        }
                    },
                };

                string ajson = JsonConvert.SerializeObject(alist);
                string afileName = $"{Name.Replace(' ', '_')}.json";
                var aappdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var adir = Path.Combine(aappdata, "C314.SmallerCSAppsBundle", "lists");
                if (!Directory.Exists(adir))
                {
                    Directory.CreateDirectory(adir);
                }
                File.WriteAllText(Path.Combine(adir, afileName), ajson);
                Console.WriteLine($"Created list {Name} with board {Board}.");
                return;
            }
            
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
            Console.WriteLine($"Created list {Name}.");
        }
    }
}
