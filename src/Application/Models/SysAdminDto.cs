using Domain.Entities;

namespace Application;

public class SysAdminDto
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string Username { get; set; }

	public static SysAdminDto Create(SysAdmin sysAdmin)
	{
		return new SysAdminDto
		{ Id = sysAdmin.Id,
		Name = sysAdmin.Name,
		LastName = sysAdmin.Lastname,
		Email = sysAdmin.Email,
		Username = sysAdmin.Username,
		};
	}

	public static List<SysAdminDto> CreateList(IEnumerable<SysAdmin> sysAdmin)
	{
		return sysAdmin.Select(s => Create(s)).ToList(); //preguntar
	}
}