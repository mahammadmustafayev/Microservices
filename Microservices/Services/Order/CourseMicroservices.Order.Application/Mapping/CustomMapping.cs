using AutoMapper;
using CourseMicroservices.Order.Application.DTOs;
using CourseMicroservices.Order.Domain.OrderAggregate;

namespace CourseMicroservices.Order.Application.Mapping;

public class CustomMapping : Profile
{
    public CustomMapping()
    {
        CreateMap<Domain.OrderAggregate.Order, OrderDTO>().ReverseMap();
        CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
        CreateMap<Address, AddressDTO>().ReverseMap();
    }
}
