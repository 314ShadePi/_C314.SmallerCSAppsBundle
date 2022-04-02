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

        [Option('b', "board", Required = false, HelpText = "The board to add the item to.")]
        public string Board { get; set; }

        [Option('t', "boarddescription", Required = false, HelpText = "The board description.")]
        public string BoardDescription { get; set; }

        [Option('q', "removeboard", Required = false, HelpText = "Remove a board.")]
        public bool RemoveBoard { get; set; }

        [Option('c', "editboard", Required = false, HelpText = "Edit a board.")]
        public bool EditBoard { get; set; }

        [Option('w', "addboard", Required = false, HelpText = "Add a board.")]
        public bool AddBoard { get; set; }

        [Option('y', "addtoboard", Required = false, HelpText = "Add an item to a board.")]
        public bool AddToBoard { get; set; }

        [Option('z', "removefromboard", Required = false, HelpText = "Remove an item from a board.")]
        public bool RemoveFromBoard { get; set; }

        [Option('x', "editinboard", Required = false, HelpText = "Edit an item in a board.")]
        public bool EditInBoard { get; set; }

        [Option('v', "advanced", Required = false, HelpText = "advanced.")]
        public bool Advanced { get; set; }

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
            if (Advanced)
            {
                CAList alist = JsonConvert.DeserializeObject<CAList>(json);
                if (AddToBoard)
                {
                    for (int i = 0; i < alist.boards.Count; i++)
                    {
                        if (alist.boards[i].name == Board)
                        {
                            if (alist.boards[i].items.Any(x => x.name == Item))
                            {
                                Console.WriteLine($"Item {Item} already exists in board {Board}.");
                                return;
                            }
                            alist.boards[i].items.Add(new Item() { name = Item, description = Description });
                            json = JsonConvert.SerializeObject(alist);
                            File.WriteAllText(path, json);
                            Console.WriteLine($"Item {Item} added to board {Board} in list {Name}.");
                            return;
                        }
                    }
                }

                if (EditInBoard)
                {
                    for (int i = 0; i < alist.boards.Count; i++)
                    {
                        if (alist.boards[i].name == Board)
                        {
                            for (int j = 0; j < alist.boards[i].items.Count; j++)
                            {
                                if (alist.boards[i].items[j].name == Item)
                                {
                                    if (NewName != null)
                                    {
                                        alist.boards[i].items[j].name = NewName;
                                    }
                                    if (Description != null)
                                    {
                                        alist.boards[i].items[j].description = Description;
                                    }
                                    json = JsonConvert.SerializeObject(alist);
                                    File.WriteAllText(path, json);
                                    Console.WriteLine($"Item {Item} edited in board {Board} in list {Name}.");
                                    return;
                                }
                            }
                        }
                    }
                }

                if (RemoveFromBoard)
                {
                    for (int i = 0; i < alist.boards.Count; i++)
                    {
                        if (alist.boards[i].name == Board)
                        {
                            for (int j = 0; j < alist.boards[i].items.Count; j++)
                            {
                                if (alist.boards[i].items[j].name == Item)
                                {
                                    alist.boards[i].items.RemoveAt(j);
                                    json = JsonConvert.SerializeObject(alist);
                                    File.WriteAllText(path, json);
                                    Console.WriteLine($"Item {Item} removed from board {Board} in list {Name}.");
                                    return;
                                }
                            }
                        }
                    }
                }

                if (AddBoard)
                {
                    alist.boards.Add(new Board() { name = Board, description = BoardDescription, items = new List<Item>() { new Item() { name = Item, description = Description } } });
                }

                if (EditBoard)
                {
                    for (int i = 0; i < alist.boards.Count; i++)
                    {
                        if (alist.boards[i].name == Board)
                        {
                            if (NewName != null)
                            {
                                alist.boards[i].name = NewName;
                            }
                            if (Description != null)
                            {
                                alist.boards[i].description = Description;
                            }
                            json = JsonConvert.SerializeObject(alist);
                            File.WriteAllText(path, json);
                            Console.WriteLine($"Board {Board} edited in list {Name}.");
                            return;
                        }
                    }
                }

                if (RemoveBoard)
                {
                    for (int i = 0; i < alist.boards.Count; i++)
                    {
                        if (alist.boards[i].name == Board)
                        {
                            alist.boards.RemoveAt(i);
                            json = JsonConvert.SerializeObject(alist);
                            File.WriteAllText(path, json);
                            Console.WriteLine($"Board {Board} removed from list {Name}.");
                            return;
                        }
                    }
                }
                return;
            }
            else
            {
                CList list = JsonConvert.DeserializeObject<CList>(json);

                if (Add && list.items != null)
                {
                    if (list.items.Any(x => x.name == Item))
                    {
                        Console.WriteLine($"Item {Item} already exists in list {Name}.");
                        return;
                    }
                    list.items.Add(new Item { name = Item, description = Description });
                    json = JsonConvert.SerializeObject(list);
                    File.WriteAllText(path, json);
                    Console.WriteLine($"Item {Item} added to list {Name}.");
                    return;
                }

                if (Edit && list.items != null)
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
                        Console.WriteLine($"Item {Item} renamed to {NewName}.");
                    }
                    if (Description != null)
                    {
                        item.description = Description;
                        Console.WriteLine($"Item {Item}'s description changed to {Description}.");
                    }
                    json = JsonConvert.SerializeObject(list);
                    File.WriteAllText(path, json);
                    return;
                }

                if (Delete && list.items != null)
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
                    Console.WriteLine($"Item {Item} removed from list {Name}.");
                    return;
                }
            }
        }
    }
}
