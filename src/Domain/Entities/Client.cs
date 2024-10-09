

using Domain.Enums;

namespace Domain.Entities
{
    public class Client : User
    {
        public string Adress {get; set;} = string.Empty;

        public Client() {}
        public Client (string name, string lastName, string email, string password, string username, string adress )
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Username = username;
            Adress = adress;
            UserType = UserType.Client;
        }
    }
}