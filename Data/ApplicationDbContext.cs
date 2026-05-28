using LogisticsTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsTrackingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor used by Dependency Injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Shipments table
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}