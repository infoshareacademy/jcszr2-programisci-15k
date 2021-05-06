using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc
{
    public class RealEstateOfficeContext : DbContext
    {
        public DbSet<Domain.FavouriteRealEstate> FavouriteRealEstates { get; set; }
        public DbSet<Domain.Image> Images { get; set; }
        public DbSet<Domain.Log> Logs { get; set; }
        public DbSet<Domain.RealEstate> RealEstates { get; set; }
        public DbSet<Domain.User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=LAPTOP-IDOLVEGJ\\SQLEXPRESS;Database=RealEstateOfficeDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
