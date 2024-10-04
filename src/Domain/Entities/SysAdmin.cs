namespace Domain.Entities;

public class SysAdmin : User

{
    public SysAdmin()
    {
         UserType = "SysAdmin";
    }
    public SysAdmin(string name,string lastName, string email,string password,string username) 
    {
        Name = name;
        LastName = lastName;
        Email = email;
        Password = password;
        Username = username;
        UserType = "SysAdmin";
    }
}