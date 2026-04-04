using EmlakPortal.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EmlakPortal.API.Data
{
    public class AppDbContext: IdentityDbContext<AppUser,AppRole,string>
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        { }
       
        public DbSet<Property>Properties { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Property>()
        .Property(p => p.Price)
        .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Property>()
        .HasOne(p => p.City)
        .WithMany(c => c.Properties)
        .HasForeignKey(p => p.CityId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Property>()
        .HasOne(p => p.District)
        .WithMany(d => d.Properties)
        .HasForeignKey(p => p.DistrictId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Property>()
        .HasOne(p => p.Category)
        .WithMany(c => c.Properties)
        .HasForeignKey(p => p.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Property>()
        .HasOne(p => p.AppUser)
        .WithMany(u => u.Properties)
        .HasForeignKey(p => p.AppUserId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<District>()
        .HasOne(d => d.City)
        .WithMany(c => c.Districts)
        .HasForeignKey(d => d.CityId)
        .OnDelete(DeleteBehavior.Cascade);


        }


    }
}
