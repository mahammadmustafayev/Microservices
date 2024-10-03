using AutoMapper;
using CourseMicroservices.Catalog.DTOs;
using CourseMicroservices.Catalog.Models;

namespace CourseMicroservices.Catalog.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Models.Course, CourseDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Feature, FeatureDTO>().ReverseMap();

        CreateMap<Models.Course, CourseCreateDTO>().ReverseMap();
        CreateMap<Models.Course, CourseUpdateDTO>().ReverseMap();
    }
}
