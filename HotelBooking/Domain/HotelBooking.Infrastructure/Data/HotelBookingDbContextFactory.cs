using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HotelBooking.Infrastructure.Data;

public class HotelBookingDbContextFactory : IDesignTimeDbContextFactory<HotelBookingDbContext>
{
    public HotelBookingDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<HotelBookingDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? "Server=(localdb)\\mssqllocaldb;Database=HotelBookingDb;Trusted_Connection=True;";

        optionsBuilder.UseSqlServer(connectionString);

        return new HotelBookingDbContext(optionsBuilder.Options);
    }
}
