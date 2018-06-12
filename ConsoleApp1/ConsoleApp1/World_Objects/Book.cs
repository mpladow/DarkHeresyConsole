namespace ConsoleApp1
{
    internal class Book:Item
    {
        public string Language { get; set; }

        public Book(int id, string name, string nameplural, string language, double weight) : base(id, name, nameplural, weight)
        {
            Language = language;
        }
    }
}