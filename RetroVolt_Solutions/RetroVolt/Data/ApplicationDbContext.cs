using Microsoft.EntityFrameworkCore;
using RetroVolt.Models;

namespace RetroVolt.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Any options configured here would be passed on to the base class DbContext.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        //Add table to database
        //We have to do a migration as well -> packet manager -> add-migration *name of migration process
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //use to seed data.Entity<where we use it>().HasData method(*creating new object)
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Shoes", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Shirts", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Pants", DisplayOrder = 3 }
                );
        }
    }
}
