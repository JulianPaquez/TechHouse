using Domain;
using Domain.Entities;


namespace Infrastructure.Repositories;

public  class SysAdminRepository : BaseRepository<SysAdmin>, ISysAdminRepository
{
    public SysAdminRepository(ApplicationContext context) : base(context)
    {
    }
}