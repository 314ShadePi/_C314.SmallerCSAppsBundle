﻿using C314.jsonTemplates;
using CommandLine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C314.SmallerCSAppsBundle.Lists
{
    [Verb("readlist", HelpText = "View list contents.")]
    public class Read : Common.IVerb
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
            var json = File.ReadAllText(path);
            CList list = JsonConvert.DeserializeObject<CList>(json);
            Console.WriteLine($"List {Name} contains {list.items.Count} items.");
            foreach (var item in list.items)
            {
                Console.WriteLine($"{item.name} - {item.description}");
            }
        }
    }
}