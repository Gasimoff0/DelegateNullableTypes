using DelegateNullableTypes.Interfaces;

namespace DelegateNullableTypes
{
    public class Book : IEntity
    {
        private static int _lastId = 0;
        public int Id { get; }
        public string Name { get; set; }
        public string AuthorName { get; private set; }
        public int PageCount { get; private set; }
        public bool IsDeleted { get; private set; }

        public Book(string name , string authorname , int pagecount)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Ad bosh ola bilmez");
            }
            if (string.IsNullOrWhiteSpace(authorname))
            {
                throw new Exception("Authorname bosh ola bilmez");
            }
            if (pagecount <= 0)
            {
                throw new Exception("Say menfi ola bilmez");
            }
            Name = name;
            AuthorName = authorname;
            PageCount = pagecount;
            Id = ++_lastId;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id} , Name: {Name} , Authorname {AuthorName} , PageCount {PageCount}");
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
