using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

       
        public DbSet<SysAdmin> SysAdmins { get; set; }
       
    }
}