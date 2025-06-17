using Microsoft.EntityFrameworkCore;
using DeliveryParcel.Domain.Entities;
using DeliveryParcel.Infrastructure.Configurations;

namespace DeliveryParcel.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Tracking> Trackings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Подключаем конфигурации
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new SenderConfiguration());
            modelBuilder.ApplyConfiguration(new RecipientConfiguration());
            modelBuilder.ApplyConfiguration(new CourierConfiguration());
            modelBuilder.ApplyConfiguration(new TrackingConfiguration());
        }
    }
}
