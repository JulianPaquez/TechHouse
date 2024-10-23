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
            // Configuración de las relaciones entre entidades
            modelBuilder.Entity<SaleDetails>()
                 .HasKey(sd => new { sd.SaleId, sd.ProductId });

            modelBuilder.Entity<SaleDetails>()
                .HasOne(sd => sd.Sale)
                .WithMany(s => s.SaleDetails)
                .HasForeignKey(sd => sd.SaleId);

            modelBuilder.Entity<SaleDetails>()
                .HasOne(sd => sd.Product)
                .WithMany()
                .HasForeignKey(sd => sd.ProductId);

            // Configuración adicional de entidades si es necesario
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            base.OnModelCreating(modelBuilder);
        }
    }
}