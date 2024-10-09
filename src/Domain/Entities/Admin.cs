using Domain.Entities;

namespace Domain.Entities;

public class Admin : User
{
    public Admin(string name, string lastName, string email, string password, string username)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        Password = password;
        Username = username;
        UserType = "Admin";
    }
    public Admin() { UserType = "Admin"; }
}