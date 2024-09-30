using Domain;
using Domain.Entities;
using Domain.Entities;
using Infrastructure.Data;


namespace Infrastructure.Repositories;

public  class AdminRepository: BaseRepository<Admin>,IAdminRepository
{
    public AdminRepository(ApplicationContext context) : base(context)
    {
    }
}
