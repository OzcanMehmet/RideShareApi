using Microsoft.EntityFrameworkCore;
using RideShare.Model;

namespace RideShare.Data
{
    public class ApiContext : DbContext
    {

        public ApiContext(DbContextOptions<ApiContext> ct):base(ct)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<TravelPlan> TravelPlan { get; set; }
       
        public DbSet<TravelGuest>  TravelGuest { get; set; }
        
    }
}