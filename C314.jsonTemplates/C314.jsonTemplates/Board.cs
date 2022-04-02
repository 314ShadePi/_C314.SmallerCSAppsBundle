namespace C314.jsonTemplates
{
    public class Board
        {
            public string name { get; set; }
            public string description { get; set; }
            public IList<Item> items { get; set; }
        }
}