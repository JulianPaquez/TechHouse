using Domain.Entities;
using Domain.Enums;

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
        UserType = UserType.Admin;
    }
    public Admin() {  }
}