using Microsoft.EntityFrameworkCore;

namespace RetroVolt.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Any options configured here would be passed on to the base class DbContext.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
    }
}
