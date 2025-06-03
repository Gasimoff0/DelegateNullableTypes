using Utils.Enums;
namespace DelegateNullableTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            Role role;
            while (true)
            {
                Console.Write("Rolunuzu daxil edin: ");
                string roleInput = Console.ReadLine();
                if (Enum.TryParse(roleInput, true, out role))
                    break;
                Console.WriteLine("Duzgun Rol daxil edin");
            }
            var user = new User(username, email, role);
            var library = new Library(10);

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Get book by id");
                Console.WriteLine("3. Get all books");
                Console.WriteLine("4. Delete book by id");
                Console.WriteLine("5. Edit book name");
                Console.WriteLine("6. Filter by page count");
                Console.WriteLine("0. Quit");

                Console.Write("Sechim edin: ");
                string choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            if (user.Role != Role.Admin)
                            {
                                Console.WriteLine("Kitab elave edile bilmedi.");
                                break;
                            }
                            Console.Write("Kitabin adi: ");
                            string name = Console.ReadLine();
                            Console.Write("Yazichinin adi: ");
                            string author = Console.ReadLine();
                            Console.Write("Sehife sayi: ");
                            int pageCount = int.Parse(Console.ReadLine());
                            library.AddBook(new Book(name, author, pageCount));
                            break;

                        case "2":
                            Console.Write("Kitab ID: ");
                            int? getId = int.Parse(Console.ReadLine());
                            var book = library.GetBookById(getId);
                            if (book != null) book.ShowInfo();
                            else Console.WriteLine("Kitab tapilmadi.");
                            break;

                        case "3":
                            foreach (var b in library.GetAllBooks())
                                b.ShowInfo();
                            break;

                        case "4":
                            if (user.Role != Role.Admin)
                            {
                                Console.WriteLine("Kitab silinmedi.");
                                break;
                            }
                            Console.Write("Kitab ID: ");
                            int? deleteId = int.Parse(Console.ReadLine());
                            library.DeleteBookById(deleteId);
                            break;

                        case "5":
                            if (user.Role != Role.Admin)
                            {
                                Console.WriteLine("Deyishiklik edilmedi.");
                                break;
                            }
                            Console.Write("Kitab ID: ");
                            int? editId = int.Parse(Console.ReadLine());
                            Console.Write("Yeni ad: ");
                            string newName = Console.ReadLine();
                            library.EditBookName(editId, newName);
                            break;

                        case "6":
                            Console.Write("Min sehife sayi: ");
                            int min = int.Parse(Console.ReadLine());
                            Console.Write("Max sehife sayi: ");
                            int max = int.Parse(Console.ReadLine());
                            var filteredBooks = library.FilterByPageCount(min, max);
                            foreach (var fb in filteredBooks)
                                fb.ShowInfo();
                            break;

                        case "0": return;

                        default: Console.WriteLine("Sehv sechim."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");


                }
            }
        }
    }
}
