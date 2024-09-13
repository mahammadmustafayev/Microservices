using Course.Shared.ControllerBases;
using CourseMicroservices.Catalog.DTOs;
using CourseMicroservices.Catalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseMicroservices.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : CustomeBaseController
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _courseService.GetAllAsync();

        return CreateActionResultInstance(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var response = await _courseService.GetByIdAsync(id);

        return CreateActionResultInstance(response);
    }
    [HttpGet]
    [Route("/api/[controller]/GetAllByUserId/{userId}")]
    public async Task<IActionResult> GetAllByUserId(string userId)
    {
        var response = await _courseService.GetAllUserIdAsync(userId);

        return CreateActionResultInstance(response);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CourseCreateDTO courseCreateDTO)
    {
        var response = await _courseService.CreateAsync(courseCreateDTO);
        return CreateActionResultInstance(response);
    }
    [HttpPut]
    public async Task<IActionResult> Update(CourseUpdateDTO courseUpdateDTO)
    {
        var response = await _courseService.UpdateAsync(courseUpdateDTO);
        return CreateActionResultInstance(response);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await _courseService.DeleteAsync(id);
        return CreateActionResultInstance(response);
    }
}
