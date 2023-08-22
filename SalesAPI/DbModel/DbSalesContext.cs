using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesAPI.DbModel
{
    public partial class DbSalesContext : DbContext
    {
        public DbSalesContext()
        {
        }

        public DbSalesContext(DbContextOptions<DbSalesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<SalesRecord> SalesRecord { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=SalesWebMvcContext-ab88af57-249f-416b-a992-365fb3316657;Integrated Security=True");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesRecord>(entity =>
            {
                entity.HasIndex(e => e.SellersId);

                /*entity.HasOne(d => d.Sellers)
                    .WithMany(p => p.SalesRecord)
                    .HasForeignKey(d => d.SellersId);*/
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId);

                /*entity.HasOne(d => d.Department)
                    .WithMany(p => p.Seller)
                    .HasForeignKey(d => d.DepartmentId);*/
            });
        }
    }
}
