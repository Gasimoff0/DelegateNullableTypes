namespace DelegateNullableTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("mahabbat", "qahsfhweg", Utils.Enums.Role.Admin);
            user.ShowInfo();
        }
    }
}
