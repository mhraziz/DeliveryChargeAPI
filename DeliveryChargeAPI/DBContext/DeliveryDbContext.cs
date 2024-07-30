using DeliveryChargeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryChargeAPI.DBContext
{
    public class DeliveryDbContext : DbContext
    {
        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<DeliveryCharge> DeliveryCharges { get; set; }
    }
}
