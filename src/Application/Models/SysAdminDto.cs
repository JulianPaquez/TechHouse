using Domain.Entities;

namespace Application;

public class SysAdminDto
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;


	public static SysAdminDto Create(SysAdmin sysAdmin)
	{
		return new SysAdminDto
		{ Id = sysAdmin.Id,
		Name = sysAdmin.Name,
		LastName = sysAdmin.LastName,
		Email = sysAdmin.Email,
		
		
		
		};
	}

	public static List<SysAdminDto> CreateList(IEnumerable<SysAdmin> sysAdmin)
	{
		return sysAdmin.Select(s => Create(s)).ToList(); //preguntar
	}
}