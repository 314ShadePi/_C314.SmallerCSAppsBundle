using C314.jsonTemplates;
using CommandLine;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C314.SmallerCSAppsBundle.Lists
{
    [Verb("updatelist", HelpText = "Update list contents.")]
    public class Update : Common.IVerb
    {
        [Option('n', "name", Required = true, HelpText = "The name of the list.")]
        public string Name { get; set; }
        
        [Option('i', "item", Required = true, HelpText = "The name of the item.")]
        public string Item { get; set; }

        [Option('d', "description", Required = false, HelpText = "The description of the item.")]
        public string Description { get; set; }

        [Option('u', "updateName", Required = false, HelpText = "The item's new name.")]
        public string NewName { get; set; }

        [Option('a', "add", Required = false, HelpText = "Add an item to the list.")]
        public bool Add { get; set; }

        [Option('e', "edit", Required = false, HelpText = "Edit an item in the list.")]
        public bool Edit { get; set; }
        
        [Option('r', "remove", Required = false, HelpText = "Remove an item from the list.")]
        public bool Delete { get; set; }

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
            var json = File.ReadAllText(path);
            CList list = JsonConvert.DeserializeObject<CList>(json);

            if (Add)
            {
                if (list.items.Any(x => x.name == Item))
                {
                    Console.WriteLine($"Item {Item} already exists in list {Name}.");
                    return;
                }
                list.items.Add(new Item { name = Item, description = Description });
                json = JsonConvert.SerializeObject(list);
                File.WriteAllText(path, json);
                return;
            }

            if (Edit)
            {
                var item = list.items.FirstOrDefault(i => i.name == Item);
                if (item == null)
                {
                    Console.WriteLine($"Item {Item} does not exist.");
                    return;
                }
                if (NewName != null)
                {
                    item.name = NewName;
                }
                if (Description != null)
                {
                    item.description = Description;
                }
                json = JsonConvert.SerializeObject(list);
                File.WriteAllText(path, json);
                return;
            }

            if (Delete)
            {
                var item = list.items.FirstOrDefault(i => i.name == Item);
                if (item == null)
                {
                    Console.WriteLine($"Item {Item} does not exist.");
                    return;
                }
                list.items.Remove(item);
                json = JsonConvert.SerializeObject(list);
                File.WriteAllText(path, json);
                return;
            }
        }

        CList list = new CList
        {
            items = new List<Item>
            {
                new Item
                {
                    name = "Item 1",
                    description = "Item 1 description"
                },
                new Item
                {
                    name = "Item 2",
                    description = "Item 2 description"
                }
            }
        };
    }
}
