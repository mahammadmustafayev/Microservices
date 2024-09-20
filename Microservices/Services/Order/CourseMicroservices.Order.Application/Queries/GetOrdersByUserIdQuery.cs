
using Course.Shared.DTOs;
using CourseMicroservices.Order.Application.DTOs;
using MediatR;

namespace CourseMicroservices.Order.Application.Queries;

public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDTO>>>
{
    public string UserId { get; set; }
}
