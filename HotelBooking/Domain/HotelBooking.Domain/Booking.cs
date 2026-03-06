using HotelBooking.Domain.Base;
using HotelBooking.Domain.Exceptions;
using HotelBooking.ValueObjects;

namespace HotelBooking.Domain;

/// <summary>
/// Represents a booking entity.
/// </summary>
public class Booking : Entity<Guid>
{
    public DateRange DateRange { get; private set; } = default!;

    public Price Price { get; private set; } = default!;

    public RoomNumber RoomNumber { get; private set; } = default!;

    public DateTime CreationDate { get; }

    public DateTime? ModificationDate { get; private set; } = null;

    public BookingStatus Status { get; private set; } = BookingStatus.Confirmed;

    public Guest Guest { get; } = default!;

    protected Booking()
    {
    }

    public Booking(
        Guest guest,
        DateRange dateRange,
        Price price,
        RoomNumber roomNumber,
        DateTime creationDate)
        : this(Guid.NewGuid(), guest, dateRange, price, roomNumber, creationDate) { }

    protected Booking(
        Guid id,
        Guest guest,
        DateRange dateRange,
        Price price,
        RoomNumber roomNumber,
        DateTime creationDate,
        DateTime? modificationDate = null,
        BookingStatus status = BookingStatus.Confirmed)
        : base(id)
    {
        Guest = guest ?? throw new ArgumentNullValueException(nameof(guest));
        DateRange = dateRange ?? throw new ArgumentNullValueException(nameof(dateRange));
        Price = price ?? throw new ArgumentNullValueException(nameof(price));
        RoomNumber = roomNumber ?? throw new ArgumentNullValueException(nameof(roomNumber));

        if (modificationDate is not null && modificationDate < creationDate)
            throw new InvalidDateRangeException(dateRange);

        CreationDate = creationDate;
        ModificationDate = modificationDate;
        Status = status;
    }

    public bool SetDateRange(DateRange newDateRange)
    {
        if (newDateRange == null) throw new ArgumentNullValueException(nameof(newDateRange));
        if (DateRange == newDateRange)
            return false;
        DateRange = newDateRange;
        return true;
    }

    public bool SetPrice(Price newPrice)
    {
        if (newPrice == null) throw new ArgumentNullValueException(nameof(newPrice));
        if (Price == newPrice)
            return false;
        Price = newPrice;
        return true;
    }

    public bool SetModificationDate(DateTime modificationDate)
    {
        if (ModificationDate == null) throw new ArgumentNullValueException(nameof(ModificationDate));
        if (CreationDate > modificationDate) throw new InvalidDateRangeException(DateRange);
        if (ModificationDate > modificationDate) throw new InvalidDateRangeException(DateRange);
        if (ModificationDate == modificationDate)
            return false;
        ModificationDate = modificationDate;
        return true;
    }

    public bool Cancel(DateTime cancellationDate)
    {
        if (cancellationDate > DateRange.CheckIn)
            throw new InvalidCancellationDateException(cancellationDate, DateRange.CheckIn);
        
        if (Status == BookingStatus.Cancelled)
            return false;
        
        Status = BookingStatus.Cancelled;
        ModificationDate = cancellationDate;
        return true;
    }

    public void CheckIn()
    {
        if (Status != BookingStatus.Confirmed)
            throw new InvalidOperationException($"Cannot check in: booking status is {Status}");
        Status = BookingStatus.CheckedIn;
        ModificationDate = DateTime.UtcNow;
    }

    public void CheckOut()
    {
        if (Status != BookingStatus.CheckedIn)
            throw new InvalidOperationException($"Cannot check out: booking status is {Status}");
        Status = BookingStatus.Completed;
        ModificationDate = DateTime.UtcNow;
    }
}
