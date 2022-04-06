using C314.JsonUtils.Templates;
using CommandLine;
using Newtonsoft.Json;

namespace C314.SmallerCSAppsBundle.Lists
{
    [Verb("readlist", HelpText = "View list contents.")]
    public class Read : Common.IVerb
    {
        [Option('n', "name", Separator = ',', Required = true, HelpText = "The name of the list(s). If there are more list seperate names with a \",\" eg. \"list1\",\"list2\"")]
        public IEnumerable<string> Name { get; set; }

        public void HandleInput()
        {
            var _name = Name.ToList();
            if (_name.Count > 1)
            {
                List<CList> cLists = new List<CList>();
                foreach (var name in _name)
                {
                    string _fileName = $"{name.Replace(' ', '_')}.json";
                    var _appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    var _dir = Path.Combine(_appdata, "C314.SmallerCSAppsBundle", "lists");
                    var _path = Path.Combine(_dir, _fileName);
                    if (!File.Exists(_path))
                    {
                        Console.WriteLine($"List {_name} does not exist.");
                        return;
                    }
                    var _json = File.ReadAllText(_path);
                    CList _list = JsonConvert.DeserializeObject<CList>(_json);
                    cLists.Add(_list);
                }
                PrettyPrint(cLists);
                return;
            }

            string fileName = $"{_name[0].Replace(' ', '_')}.json";
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dir = Path.Combine(appdata, "C314.SmallerCSAppsBundle", "lists");
            var path = Path.Combine(dir, fileName);
            if (!File.Exists(path))
            {
                Console.WriteLine($"List {_name} does not exist.");
                return;
            }
            var json = File.ReadAllText(path);
            CList list = JsonConvert.DeserializeObject<CList>(json);
            list.PrettyPrint();
        }

        void PrettyPrint(List<CList> cLists, string indent = "", bool isLast = true)
        {
            var marker = isLast ? "└──" : "├──";
            Console.Write(indent);
            Console.Write(marker);
            Console.WriteLine("Multiple lists");
            indent += isLast ? "   " : "|  ";
            var lastChild = cLists.Count - 1;
            for (int i = 0; i < cLists.Count; i++)
            {
                cLists[i].PrettyPrint(indent, i == lastChild);
            }
        }
    }
}
