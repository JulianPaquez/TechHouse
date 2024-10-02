using Domain;
using Domain.Entities;



namespace Infrastructure.Repositories;

public  class AdminRepository: BaseRepository<Admin>,IAdminRepository
{
    public AdminRepository(ApplicationContext context) : base(context)
    {
    }
}
