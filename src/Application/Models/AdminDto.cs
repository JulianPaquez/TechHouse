using Domain.Entities;

namespace Application;

public class AdminDto
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;



    public static AdminDto Create(Admin Admin)
    {
        return new AdminDto
        {
            Id = Admin.Id,
            Name = Admin.Name,
            Username = Admin.Username,
            Password = Admin.Password,




        };
    }

    public static List<AdminDto> CreateList(IEnumerable<Admin> Admin)
    {
        return Admin.Select(s => Create(s)).ToList(); //preguntar
    }
}