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
        public DbSet<Admin> Admins { get; set; }
<<<<<<< HEAD
=======
        public DbSet<User> Users { get; set; }

>>>>>>> 67bf13086a3096628ab4a18971c42a15465471bf
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }

    }
}