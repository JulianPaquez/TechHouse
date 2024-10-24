using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SysAdmin> SysAdmins { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetails> SalesDetails { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la entidad SaleDetails
            modelBuilder.Entity<SaleDetails>()
                .HasKey(sd => sd.Id); // Usamos solo Id como clave primaria

            modelBuilder.Entity<SaleDetails>()
                .HasOne(sd => sd.Sale)
                .WithMany(s => s.SaleDetails)
                .HasForeignKey(sd => sd.SaleId);

            modelBuilder.Entity<SaleDetails>()
                .HasOne(sd => sd.Product)
                .WithMany(p => p.SaleDetails)
                .HasForeignKey(sd => sd.ProductId);

            base.OnModelCreating(modelBuilder);
        }

    }
}