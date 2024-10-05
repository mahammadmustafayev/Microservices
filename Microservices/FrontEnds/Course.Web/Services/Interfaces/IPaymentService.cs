using Course.Web.Models.FakePayments;

namespace Course.Web.Services.Interfaces;

public interface IPaymentService
{
    Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput);
}
