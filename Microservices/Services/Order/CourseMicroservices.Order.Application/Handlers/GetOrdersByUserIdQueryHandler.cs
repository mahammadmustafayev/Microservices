using Course.Shared.DTOs;
using CourseMicroservices.Order.Application.DTOs;
using CourseMicroservices.Order.Application.Mapping;
using CourseMicroservices.Order.Application.Queries;
using CourseMicroservices.Order.Infastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CourseMicroservices.Order.Application.Handlers;

public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Response<List<OrderDTO>>>
{
    private readonly OrderDbContext _context;

    public GetOrdersByUserIdQueryHandler(OrderDbContext context)
    {
        _context = context;
    }
    public async Task<Response<List<OrderDTO>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
    {
        var orders = await _context.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == request.UserId).ToListAsync();

        if (!orders.Any())
        {
            return Response<List<OrderDTO>>.Success(new List<OrderDTO>(), 200);
        }

        var ordersDto = ObjectMapper.Mapper.Map<List<OrderDTO>>(orders);

        return Response<List<OrderDTO>>.Success(ordersDto, 200);
    }
}
