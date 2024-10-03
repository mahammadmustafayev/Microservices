using Course.Shared.DTOs;
using CourseMicroservices.Catalog.DTOs;

namespace CourseMicroservices.Catalog.Services;

public interface ICategoryService
{
    Task<Response<List<CategoryDTO>>> GetAllAsync();
    Task<Response<CategoryDTO>> CreateAsync(CategoryCreateDTO categoryCreateDto);
    Task<Response<CategoryDTO>> GetByIdAsync(string id);
}
