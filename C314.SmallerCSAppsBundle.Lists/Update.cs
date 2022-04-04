using C314.JsonUtils.Templates;
using CommandLine;
using Newtonsoft.Json;

namespace C314.SmallerCSAppsBundle.Lists
{
    [Verb("updatelist", HelpText = "Update list contents.")]
    public class Update : Common.IVerb
    {
        [Option('n', "name", Required = true, HelpText = "The name of the list.")]
        public string Name { get; set; }
        
        [Option('i', "item", Required = false, HelpText = "The name of the item. If not specified, the current board will be updated instead.")]
        public string Item { get; set; }

        [Option('d', "description", Required = false, HelpText = "The description of the item/board.")]
        public string Description { get; set; }

        [Option('u', "updateName", Required = false, HelpText = "The item/board's new name.")]
        public string NewName { get; set; }

        [Option('a', "add", Required = false, HelpText = "Add an item/board to the list.")]
        public bool Add { get; set; }

        [Option('e', "edit", Required = false, HelpText = "Edit an item/board in the list/board.")]
        public bool Edit { get; set; }
        
        [Option('r', "remove", Required = false, HelpText = "Remove an item/board from the list/board.")]
        public bool Delete { get; set; }

        [Option('b', "board", Required = true, HelpText = "The board to edit.")]
        public string Board { get; set; }

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
                if (String.IsNullOrEmpty(Item))
                {
                    if (list.boards.Any(x => x.name == Board))
                    {
                        Console.WriteLine($"Board {Board} already exists in list {Name}.");
                        return;
                    }
                    list.boards.Add(new Board() { name = Board, description = Description, items = new List<Item>() { } });
                    json = JsonConvert.SerializeObject(list);
                    File.WriteAllText(path, json);
                    Console.WriteLine($"Board {Board} added to list {Name}.");
                    return;
                }
                for (int i = 0; i < list.boards.Count; i++)
                {
                    if (list.boards[i].name == Board)
                    {
                        if (list.boards[i].items.Any(x => x.name == Item))
                        {
                            Console.WriteLine($"Item {Item} already exists in board {Board}.");
                            return;
                        }
                        list.boards[i].items.Add(new Item() { name = Item, description = Description });
                        json = JsonConvert.SerializeObject(list);
                        File.WriteAllText(path, json);
                        Console.WriteLine($"Item {Item} added to board {Board} in list {Name}.");
                        return;
                    }
                }
            }

            if (Edit)
            {
                if (String.IsNullOrEmpty(Item))
                {
                    for (int i = 0; i < list.boards.Count; i++)
                    {
                        if (list.boards[i].name == Board)
                        {
                            if (NewName != null)
                            {
                                list.boards[i].name = NewName;
                            }
                            if (Description != null)
                            {
                                list.boards[i].description = Description;
                            }
                            json = JsonConvert.SerializeObject(list);
                            File.WriteAllText(path, json);
                            Console.WriteLine($"Board {Board} edited in list {Name}.");
                            return;
                        }
                    }
                    return;
                }

                for (int i = 0; i < list.boards.Count; i++)
                {
                    if (list.boards[i].name == Board)
                    {
                        for (int j = 0; j < list.boards[i].items.Count; j++)
                        {
                            if (list.boards[i].items[j].name == Item)
                            {
                                if (NewName != null)
                                {
                                    list.boards[i].items[j].name = NewName;
                                }
                                if (Description != null)
                                {
                                    list.boards[i].items[j].description = Description;
                                }
                                json = JsonConvert.SerializeObject(list);
                                File.WriteAllText(path, json);
                                Console.WriteLine($"Item {Item} edited in board {Board} in list {Name}.");
                                return;
                            }
                        }
                    }
                }
            }

            if (Delete)
            {
                if (String.IsNullOrEmpty(Item))
                {
                    for (int i = 0; i < list.boards.Count; i++)
                    {
                        if (list.boards[i].name == Board)
                        {
                            list.boards.RemoveAt(i);
                            json = JsonConvert.SerializeObject(list);
                            File.WriteAllText(path, json);
                            Console.WriteLine($"Board {Board} removed from list {Name}.");
                            return;
                        }
                    }
                    return;
                }

                for (int i = 0; i < list.boards.Count; i++)
                {
                    if (list.boards[i].name == Board)
                    {
                        for (int j = 0; j < list.boards[i].items.Count; j++)
                        {
                            if (list.boards[i].items[j].name == Item)
                            {
                                list.boards[i].items.RemoveAt(j);
                                json = JsonConvert.SerializeObject(list);
                                File.WriteAllText(path, json);
                                Console.WriteLine($"Item {Item} removed from board {Board} in list {Name}.");
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
