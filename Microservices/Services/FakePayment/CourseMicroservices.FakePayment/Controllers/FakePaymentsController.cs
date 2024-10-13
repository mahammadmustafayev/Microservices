using Course.Shared.ControllerBases;
using Course.Shared.DTOs;
using Course.Shared.Messages;
using CourseMicroservices.FakePayment.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace CourseMicroservices.FakePayment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FakePaymentsController : CustomeBaseController
{
    private readonly ISendEndpointProvider _sendEndpointProvider;

    public FakePaymentsController(ISendEndpointProvider sendEndpointProvider)
    {
        _sendEndpointProvider = sendEndpointProvider;
    }

    [HttpPost]
    public async Task<IActionResult> ReceivePayment(PaymentDto paymentDto)
    {
        var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-order-service"));
        var createOrderMessageCommand = new CreateOrderMessageCommand();

        createOrderMessageCommand.BuyerId = paymentDto.Order.BuyerId;
        createOrderMessageCommand.Province = paymentDto.Order.Address.Province;
        createOrderMessageCommand.District = paymentDto.Order.Address.District;
        createOrderMessageCommand.Street = paymentDto.Order.Address.Street;
        createOrderMessageCommand.Line = paymentDto.Order.Address.Line;
        createOrderMessageCommand.ZipCode = paymentDto.Order.Address.ZipCode;

        paymentDto.Order.OrderItems.ForEach(x =>
        {
            createOrderMessageCommand.OrderItems.Add(new OrderItem
            {
                PictureUrl = x.PictureUrl,
                Price = x.Price,
                ProductId = x.ProductId,
                ProductName = x.ProductName
            });
        });

        await sendEndpoint.Send<CreateOrderMessageCommand>(createOrderMessageCommand);

        return CreateActionResultInstance(Course.Shared.DTOs.Response<NoContent>.Success(200));
    }
}
