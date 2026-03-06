using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelBooking.Infrastructure.Data;

public class HotelBookingDbContextFactory : IDesignTimeDbContextFactory<HotelBookingDbContext>
{
    public HotelBookingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HotelBookingDbContext>();
        
        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;Database=HotelBookingDb;Trusted_Connection=True;"
        );

        return new HotelBookingDbContext(optionsBuilder.Options);
    }
}
