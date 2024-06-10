namespace SmartLibrary.API.Entities
{
    public class Book
    {
        public Book()
        {
            
        }
        public Book(string title, string author, string isnb, int publicationYear)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            ISBN = isnb;
            PublicationYear = publicationYear;
            IsRemoved = false;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public bool IsRemoved { get; set; }

        public void RemoveBook()
        {
            IsRemoved = true;
        }
    }
}
