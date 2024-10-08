﻿using Course.Shared.ControllerBases;
using Course.Shared.Services;
using CourseMicroservices.Discount.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseMicroservices.Discount.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountsController : CustomeBaseController
{
    private readonly IDiscountService _discountService;
    private readonly ISharedIdentityService _sharedIdentityService;
    public DiscountsController(IDiscountService discountService, ISharedIdentityService sharedIdentityService)
    {
        _discountService = discountService;
        _sharedIdentityService = sharedIdentityService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResultInstance(await _discountService.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return CreateActionResultInstance(await _discountService.GetById(id));
    }
    [HttpGet]
    [Route("/api/[controller]/[action]/{code}")]
    public async Task<IActionResult> GetByCode(string code)
    {
        var userId = _sharedIdentityService.GetUserId;
        return CreateActionResultInstance(await _discountService.GetByCodeAndUserId(code, userId));
    }
    [HttpPost]
    public async Task<IActionResult> Save(Models.Discount discount)
    {
        return CreateActionResultInstance(await _discountService.Save(discount));
    }
    [HttpPut]
    public async Task<IActionResult> Update(Models.Discount discount)
    {
        return CreateActionResultInstance(await _discountService.Update(discount));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return CreateActionResultInstance(await _discountService.Delete(id));
    }
}
