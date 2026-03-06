namespace HotelBooking.Domain.Exceptions;

public class InvalidCancellationDateException(DateTime cancellationDate, DateTime checkInDate)
    : InvalidOperationException(
        $"Cannot cancel booking: Cancellation date ({cancellationDate}) is after check-in date ({checkInDate}).")
{
    public DateTime CancellationDate => cancellationDate;
    public DateTime CheckInDate => checkInDate;
}
