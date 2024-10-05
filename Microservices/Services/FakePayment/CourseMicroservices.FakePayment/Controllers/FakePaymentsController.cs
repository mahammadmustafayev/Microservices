using Course.Shared.ControllerBases;
using Course.Shared.DTOs;
using CourseMicroservices.FakePayment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseMicroservices.FakePayment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FakePaymentsController : CustomeBaseController
{


    [HttpPost]
    public IActionResult ReceivePayment(PaymentDto paymentDto)
    {
        return CreateActionResultInstance(Response<NoContent>.Success(200));
    }
}
