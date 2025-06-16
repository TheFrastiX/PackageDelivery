using System;
using System.Collections.Generic;

namespace DeliveryParcel.Domain.Enums
{
    /// <summary>
    /// Перечисление статусов заказа (посылки) в системе доставки.
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Заказ только создан пользователем (черновик).
        /// </summary>
        Created = 0,

        /// <summary>
        /// Заказ подтвержден и находится в обработке.
        /// </summary>
        Confirmed = 1,

        /// <summary>
        /// Посылка принята на склад или передана курьеру.
        /// </summary>
        InProcessing = 2,

        /// <summary>
        /// Курьер назначен и ожидает забирания посылки.
        /// </summary>
        AwaitingPickup = 3,

        /// <summary>
        /// Посылка в пути, находится у курьера.
        /// </summary>
        InTransit = 4,

        /// <summary>
        /// Посылка успешно доставлена получателю.
        /// </summary>
        Delivered = 5,

        /// <summary>
        /// Доставка завершена, но не подтверждена получателем.
        /// </summary>
        DeliveredUnconfirmed = 6,

        /// <summary>
        /// Заказ отменен системой (например, из-за истечения времени хранения).
        /// </summary>
        SystemCancelled = 7,

        /// <summary>
        /// Заказ отменен пользователем (отправителем).
        /// </summary>
        UserCancelled = 8,

        /// <summary>
        /// Заказ отменен курьером.
        /// </summary>
        CourierCancelled = 9,

        /// <summary>
        /// Возникла ошибка при доставке (например, недоступный адрес).
        /// </summary>
        Failed = 10,

        /// <summary>
        /// Посылка возвращена отправителю.
        /// </summary>
        Returned = 11
    }
}
