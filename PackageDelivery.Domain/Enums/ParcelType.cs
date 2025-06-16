using System;

namespace DeliveryParcel.Domain.Enums
{
    /// <summary>
    /// Типы посылок для классификации при оформлении и доставке
    /// </summary>
    public enum ParcelType
    {
        /// <summary> Стандартная посылка без особых требований </summary>
        Standard = 10,

        /// <summary> Хрупкая посылка (стекло, электроника и т.д.) </summary>
        Fragile = 20,

        /// <summary> Посылка с опасными или регулируемыми веществами </summary>
        Hazardous = 30,

        /// <summary> Крупногабаритная посылка </summary>
        Oversized = 40,

        /// <summary> Посылка, требующая температурного контроля </summary>
        TemperatureControlled = 50,

        /// <summary> Документы (ценные или конфиденциальные) </summary>
        Documents = 60,

        /// <summary> Ценное имущество (ювелирные изделия, техника и т.д.) </summary>
        Valuable = 70,

        /// <summary> Посылка, предназначенная для самовывоза </summary>
        PickupOnly = 80,

        /// <summary> Почтовое отправление стандартного размера (например, конверт) </summary>
        Letter = 90,

        /// <summary> Сезонные/специальные категории (например, Новый год, Black Friday) </summary>
        SeasonalSpecial = 100,

        /// <summary> Нестандартный тип посылки </summary>
        Custom = 110
    }
}
