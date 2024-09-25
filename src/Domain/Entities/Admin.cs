using Domain.Entities;

namespace Domain.Entites;

public class Admin : User
{
   
    public Admin(string name, string username,string password)
    {
        Name = name;
        Username = username;
        Password = password;
       

    }
}