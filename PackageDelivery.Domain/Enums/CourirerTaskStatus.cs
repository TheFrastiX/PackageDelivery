using System;
using System.Collections.Generic;

namespace DeliveryParcel.Domain.Enums
{
    /// <summary>
    /// Перечисление статусов задачи курьера в системе доставки посылок.
    /// </summary>
    public enum CourierTaskStatus
    {
        /// <summary>
        /// Задача создана, но еще не назначена курьеру.
        /// </summary>
        Created = 0,

        /// <summary>
        /// Задача назначена курьеру, ожидает подтверждения.
        /// </summary>
        Assigned = 1,

        /// <summary>
        /// Курьер подтвердил задачу, готовится к выполнению.
        /// </summary>
        Confirmed = 2,

        /// <summary>
        /// Курьер выехал за посылкой (на пути к отправителю).
        /// </summary>
        OnTheWayToSender = 3,

        /// <summary>
        /// Посылка забрана у отправителя.
        /// </summary>
        ParcelPickedUp = 4,

        /// <summary>
        /// Курьер в пути к получателю.
        /// </summary>
        Delivering = 5,

        /// <summary>
        /// Посылка успешно доставлена получателю.
        /// </summary>
        Delivered = 6,

        /// <summary>
        /// Доставка отменена (по причине отказа, недоступности и т.п.).
        /// </summary>
        Canceled = 7,

        /// <summary>
        /// Возникла проблема при доставке (например, адрес указан неверно).
        /// </summary>
        Failed = 8,

        /// <summary>
        /// Посылка возвращена отправителю.
        /// </summary>
        ReturnedToSender = 9
    }
}
