using Course.Shared.DTOs;
using CourseMicroservices.Basket.DTOs;

namespace CourseMicroservices.Basket.Services;

public interface IBasketService
{
    Task<Response<BasketDTO>> GetBasket(string userId);
    Task<Response<bool>> SaveOrUpdate(BasketDTO basketDTO);
    Task<Response<bool>> Delete(string userId);
}
