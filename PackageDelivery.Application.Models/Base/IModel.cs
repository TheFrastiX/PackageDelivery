namespace DeliveryParcel.Application.Models.Base
{
    /// <summary>
    /// Generic-интерфейс для всех моделей
    /// </summary>
    public interface IModel<TId> where TId : struct
    {
        TId Id { get; set; }
    }
}
