using AutoMapper;
using DeliveryParcel.Domain.Entities;
using DeliveryParcel.Application.Models.Orders;
using DeliveryParcel.Application.Models.Senders;
using DeliveryParcel.Application.Models.Recipients;
using DeliveryParcel.Application.Models.Couriers;
using DeliveryParcel.Application.Models.Tracking;

namespace DeliveryParcel.Application.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Order -> OrderDto
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            // Sender -> SenderDto
            CreateMap<Sender, SenderDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // Recipient -> RecipientDto
            CreateMap<Recipient, RecipientDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // Courier -> CourierDto
            CreateMap<Courier, CourierDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // Tracking -> TrackingEventDto
            CreateMap<Tracking, TrackingEventDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
