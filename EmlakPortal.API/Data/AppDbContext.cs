using EmlakPortal.Api.Models;
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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Property>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }

       
    }
}
