using DelegateNullableTypes.Interfaces;
using Utils.Exceptions;

namespace DelegateNullableTypes
{
    public class Library : IEntity
    {
        private static int _lastId = 0;
        public int Id { get; }
        public int BookLimit { get; set; }
        private List<Book> _books = new List<Book>();

        public Library(int booklimit)
        {
            if (booklimit <= 0)
            {
                throw new Exception("Kitab limiti 0-dan boyuk olmalidir");
            }
            BookLimit = booklimit;
            Id = ++_lastId;
        }
        public void AddBook(Book book)
        {
            if (_books.Count(b => !b.IsDeleted) > BookLimit)
                throw new CapacityLimitExceoption("Kitab limiti doludur");

            bool alreadyExists = _books.Any(b => !b.IsDeleted && b.Name.Equals(book.Name, StringComparison.OrdinalIgnoreCase));

            if (alreadyExists)
                throw new AlreadyExistsException("Bu adda kitab movcuddur");

            _books.Add(book);
        }

        public Book? GetBookById(int? id)
        {
            if (id == null)
                throw new Exception("id bosh ola bilmez");
            return _books.FirstOrDefault(b => !b.IsDeleted && b.Id == id);
        }

        public List<Book> GetAllBooks()
        {
            return new List<Book>(_books);
        }

        public void DeleteBookById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("Id bosh ola bilmez.");

            var book = _books.FirstOrDefault(b => !b.IsDeleted && b.Id == id);

            if (book == null)
                throw new NotFoundException("Kitab tapilmadi.");

            book.Delete();
        }

        public void EditBookName(int? id, string newName)
        {
            if (id == null)
                throw new NullReferenceException("Id bosh ola bilmez.");

            var book = _books.FirstOrDefault(b => !b.IsDeleted && b.Id == id);

            if (book == null)
                throw new NotFoundException("Kitab tapilmadi.");

            if (string.IsNullOrWhiteSpace(newName))
                throw new Exception("Yeni ad bosh ola bilmez.");

            book.Name = newName;
        }

        public List<Book> FilterByPageCount(int minPageCount, int maxPageCount)
        {
            return _books.Where(b => !b.IsDeleted && b.PageCount >= minPageCount && b.PageCount <= maxPageCount).ToList();
        }


    }
}
