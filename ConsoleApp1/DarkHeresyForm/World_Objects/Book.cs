namespace ConsoleApp1
{
    internal class Book:Item_base
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string MessageWhenRead { get; set; }
        public bool hasBeenRead { get; set; }

        public Book(int id, string name, string nameplural, string language,  string messagewhenread, double weight, bool hasbeenread = false) : base(name, nameplural, weight)
        {
            Language = language;
            MessageWhenRead = messagewhenread;
        }
    }
}