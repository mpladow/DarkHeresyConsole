namespace ConsoleApp1
{
    internal class Book:Item
    {
        public string Language { get; set; }

        public Book(string name, string language, double weight): base(name, weight)
        {
            Language = language;
        }
    }
}