﻿using Course.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Course.Web.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _userService.GetUser());
    }
}
