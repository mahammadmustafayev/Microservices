using Course.Shared.DTOs;
using CourseMicroservices.Catalog.DTOs;

namespace CourseMicroservices.Catalog.Services;

public interface ICourseService
{
    Task<Response<List<CourseDTO>>> GetAllAsync();
    Task<Response<CourseDTO>> GetByIdAsync(string id);
    Task<Response<List<CourseDTO>>> GetAllUserIdAsync(string userId);
    Task<Response<CourseDTO>> CreateAsync(CourseCreateDTO courseCreateDTO);
    Task<Response<NoContent>> UpdateAsync(CourseUpdateDTO courseUpdateDTO);
    Task<Response<NoContent>> DeleteAsync(string id);
}
