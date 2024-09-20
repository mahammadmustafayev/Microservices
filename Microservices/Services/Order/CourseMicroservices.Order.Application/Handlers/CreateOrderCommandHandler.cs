using Course.Shared.DTOs;
using CourseMicroservices.Order.Application.Commands;
using CourseMicroservices.Order.Application.DTOs;
using CourseMicroservices.Order.Domain.OrderAggregate;
using CourseMicroservices.Order.Infastructure;
using MediatR;

namespace CourseMicroservices.Order.Application.Handlers;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDTO>>
{
    private readonly OrderDbContext _context;


    public CreateOrderCommandHandler(OrderDbContext context)
    {
        _context = context;
    }

    public async Task<Response<CreatedOrderDTO>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var newAddress = new Address(request.Address.Province, request.Address.District, request.Address.Street, request.Address.ZipCode, request.Address.Line);

        Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);

        request.OrderItems.ForEach(x =>
        {
            newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);
        });

        await _context.Orders.AddAsync(newOrder);

        await _context.SaveChangesAsync();

        return Response<CreatedOrderDTO>.Success(new CreatedOrderDTO { OrderId = newOrder.Id }, 200);
    }
}
