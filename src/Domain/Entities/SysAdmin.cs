namespace Domain.Entities;

public class SysAdmin : User

{
    public SysAdmin(string name,string lastName, string username, string password) 
    {
        Name = name;
        LastName = lastName;
        Username = username;
        Password = password;
    }
}