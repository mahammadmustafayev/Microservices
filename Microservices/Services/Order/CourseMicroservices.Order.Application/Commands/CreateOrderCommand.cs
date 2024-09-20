
using Course.Shared.DTOs;
using CourseMicroservices.Order.Application.DTOs;
using MediatR;

namespace CourseMicroservices.Order.Application.Commands;

public class CreateOrderCommand : IRequest<Response<CreatedOrderDTO>>
{
    public string BuyerId { get; set; }

    public List<OrderItemDTO> OrderItems { get; set; }

    public AddressDTO Address { get; set; }
}
