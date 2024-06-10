using SmartLibrary.API.Entities;

namespace SmartLibrary.API.Persistence
{
    public class BooksDbContext
    {
        public List<Book> Books {  get; set; }
        public BooksDbContext()
        {
            Books = new List<Book>();
        }
    }
}
