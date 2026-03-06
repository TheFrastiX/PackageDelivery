using Microsoft.EntityFrameworkCore;
using HotelBooking.Domain;
using HotelBooking.Domain.Repositories.Abstractions;
using HotelBooking.Infrastructure.Data;
using HotelBooking.ValueObjects;

namespace HotelBooking.Infrastructure.Repositories;

public class GuestRepository(HotelBookingDbContext context)
    : EfRepository<Guest, Guid>(context), IGuestRepository
{
    private readonly DbSet<Guest> _guests = context.Set<Guest>();

    public override Task<Guest?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => _guests.Include("_bookings")
        .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);

    public Task<Guest?> GetByEmailAsync(Email email, CancellationToken cancellationToken)
        => _guests.Include("_bookings")
        .FirstOrDefaultAsync(g => g.Email.Value == email.Value, cancellationToken);

    public Task<Guest?> GetByNameAsync(GuestName name, CancellationToken cancellationToken)
        => _guests.Include("_bookings")
        .FirstOrDefaultAsync(g => g.Name.Value == name.Value, cancellationToken);
}
