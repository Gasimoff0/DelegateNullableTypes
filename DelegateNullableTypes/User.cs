using DelegateNullableTypes.Interfaces;
using Utils.Enums;

namespace DelegateNullableTypes
{
    public class User: IEntity
    {
        private static int _lastId = 0;
        public int Id { get; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public Role Role { get; private set; }

        public User(string username , string email , Role role)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Username bosh ola bilmez");

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email bosh ola bilmez");

            Username = username;
            Email = email;
            Role = role;
            Id = ++_lastId;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, Username: {Username}, Email: {Email}, Role: {Role}");
        }
    }
}
