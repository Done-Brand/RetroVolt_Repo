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
    }
}
