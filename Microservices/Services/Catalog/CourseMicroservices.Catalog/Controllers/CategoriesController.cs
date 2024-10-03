using Course.Shared.ControllerBases;
using CourseMicroservices.Catalog.DTOs;
using CourseMicroservices.Catalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseMicroservices.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : CustomeBaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _categoryService.GetAllAsync();
        return CreateActionResultInstance(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var response = await _categoryService.GetByIdAsync(id);
        return CreateActionResultInstance(response);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateDTO categoryCreateDTO)
    {
        var response = await _categoryService.CreateAsync(categoryCreateDTO);
        return CreateActionResultInstance(response);
    }

}
