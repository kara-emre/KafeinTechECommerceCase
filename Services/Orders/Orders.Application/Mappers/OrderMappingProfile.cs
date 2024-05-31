using AutoMapper;
using Orders.Application.Commands;
using Orders.Application.Dtos;
using Orders.Application.Reponses;
using Orders.Core.Entities;

namespace Orders.Application.Mappers
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<CreateOrderCommand, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.Products));

            CreateMap<OrderProduct, OrderItem>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<Order, CreatedOrderResponse>()
              .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src));

            CreateMap<OrderItem, ProductDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price));

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderItems));
        }
    }
}
