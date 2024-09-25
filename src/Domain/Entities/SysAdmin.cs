namespace Domain.Entities;

public class SysAdmin : User

{
    public SysAdmin(string name, string username, string password) 
    {
        Name = name;
        Username = username;
        Password = password;
    }
}