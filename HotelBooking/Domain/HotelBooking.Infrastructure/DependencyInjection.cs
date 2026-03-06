using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HotelBooking.Domain.Repositories.Abstractions;
using HotelBooking.Infrastructure.Data;
using HotelBooking.Infrastructure.Repositories;

namespace HotelBooking.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<HotelBookingDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(HotelBookingDbContext).Assembly.FullName)));

        services.AddScoped<IGuestRepository, GuestRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();

        return services;
    }
}
