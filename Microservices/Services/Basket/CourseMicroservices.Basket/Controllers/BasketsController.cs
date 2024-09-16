﻿using Course.Shared.ControllerBases;
using Course.Shared.Services;
using CourseMicroservices.Basket.DTOs;
using CourseMicroservices.Basket.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseMicroservices.Basket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController : CustomeBaseController
{
    private readonly IBasketService _basketService;
    private readonly ISharedIdentityService _sharedIdentityService;

    public BasketsController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
    {
        _basketService = basketService;
        _sharedIdentityService = sharedIdentityService;
    }
    [HttpGet]
    public async Task<IActionResult> GetBasket()
    {
        return CreateActionResultInstance(await _basketService.GetBasket(_sharedIdentityService.GetUserId));
    }
    [HttpPost]
    public async Task<IActionResult> SaveOrUpdateBasket(BasketDTO basketDTO)
    {
        basketDTO.UserId = _sharedIdentityService.GetUserId;
        var response = await _basketService.SaveOrUpdate(basketDTO);
        return CreateActionResultInstance(response);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteBasket()
    {
        return CreateActionResultInstance(await _basketService.Delete(_sharedIdentityService.GetUserId));
    }
}
