using HotelBooking.Domain;
using HotelBooking.Domain.Exceptions;
using HotelBooking.ValueObjects;

namespace HotelBookingApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🏨 HotelBooking Domain Demo\n");

        try
        {
            // ============================================
            // 1. Создание гостя (Aggregate Root)
            // ============================================
            Console.WriteLine("Создаём гостя...");
            var guest = new Guest(
                Guid.NewGuid(),
                new GuestName("Иван Петров"),
                new Email("ivan.petrov@example.com")
            );
            Console.WriteLine($"Гость создан: {guest.Name} ({guest.Email})\n");

            // ============================================
            // 2. Создание брони (через агрегат)
            // ============================================
            Console.WriteLine("Создаём бронь...");
            var booking = guest.CreateBooking(
                new DateRange(
                    new DateTime(2024, 06, 15, 14, 0, 0),
                    new DateTime(2024, 06, 20, 12, 0, 0)
                ),
                new Price(150.00m, "USD"),
                new RoomNumber("305")
            );
            Console.WriteLine($"Бронь создана: {booking.Id}");
            Console.WriteLine($"Даты: {booking.DateRange.CheckIn:dd.MM} - {booking.DateRange.CheckOut:dd.MM}");
            Console.WriteLine($"Цена: {booking.Price}");
            Console.WriteLine($"Номер: {booking.RoomNumber}");
            Console.WriteLine($"Статус: {booking.Status}\n");

            // ============================================
            // 3. Редактирование брони (через агрегат)
            // ============================================
            Console.WriteLine(" Редактируем бронь...");
            var isEdited = guest.EditBooking(
                booking,
                new DateRange(
                    new DateTime(2024, 06, 16, 14, 0, 0),
                    new DateTime(2024, 06, 20, 12, 0, 0)
                ),
                new Price(140.00m, "USD")
            );
            Console.WriteLine($" Бронь {(isEdited ? "изменена" : "не изменена")}\n");

            // ============================================
            // 4. Проверка инвариантов: отмена брони
            // ============================================
            Console.WriteLine(" Пробуем отменить бронь (некорректная дата)...");
            try
            {
                // Пытаемся отменить после даты заезда — должно выбросить исключение
                guest.CancelBooking(booking, new DateTime(2024, 06, 18));
            }
            catch (InvalidCancellationDateException ex)
            {
                Console.WriteLine($" Ожидаемое исключение: {ex.Message}\n");
            }

            // ============================================
            // 5. Корректная отмена брони
            // ============================================
            Console.WriteLine(" Отменяем бронь (корректная дата)...");
            var isCancelled = guest.CancelBooking(booking, new DateTime(2024, 06, 10));
            Console.WriteLine($" Бронь {(isCancelled ? "отменена" : "не отменена")}");
            Console.WriteLine($"  Новый статус: {booking.Status}\n");

            // ============================================
            // 6. Проверка защиты агрегата
            // ============================================
            Console.WriteLine("Проверяем защиту агрегата...");
            var anotherGuest = new Guest(
                Guid.NewGuid(),
                new GuestName("Мария Сидорова"),
                new Email("maria@example.com")
            );
            
            try
            {
                // Чужой гость не может редактировать бронь
                anotherGuest.EditBooking(booking, booking.DateRange, booking.Price);
            }
            catch (GuestNotOwnerOfBookingException ex)
            {
                Console.WriteLine($" Ожидаемое исключение: {ex.Message}\n");
            }

            // ============================================
            // 7. Демонстрация неизменяемости ValueObjects
            // ============================================
            Console.WriteLine(" Проверяем неизменяемость ValueObjects...");
            var originalName = guest.Name;
            Console.WriteLine($"Имя гостя: {originalName}");
            Console.WriteLine($"Сравнение: {originalName == guest.Name} (должно быть True)");
            Console.WriteLine($"HashCode: {originalName.GetHashCode()} == {guest.Name.GetHashCode()}\n");

            // ============================================
            // 8. Демонстрация инкапсуляции коллекции
            // ============================================
            Console.WriteLine(" Проверяем инкапсуляцию коллекции...");
            Console.WriteLine($" Количество броней: {guest.Bookings.Count}");
            Console.WriteLine($" Тип коллекции: {guest.Bookings.GetType().Name}");
            Console.WriteLine($" IReadOnly: {guest.Bookings.IsReadOnly}\n");

            Console.WriteLine("Demo completed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine($"Stack: {ex.StackTrace}");
        }
    }
}
