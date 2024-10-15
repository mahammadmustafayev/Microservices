using AutoMapper;
using Course.Shared.DTOs;
using Course.Shared.Messages;
using CourseMicroservices.Catalog.DTOs;
using CourseMicroservices.Catalog.Models;
using CourseMicroservices.Catalog.Settings;
using MongoDB.Driver;

namespace CourseMicroservices.Catalog.Services;

public class CourseService : ICourseService
{
    private readonly IMongoCollection<Models.Course> _courseCollection;
    private readonly IMongoCollection<Category> _categoryCollection;

    private readonly IMapper _mapper;
    private readonly MassTransit.IPublishEndpoint _publishEndpoint;
    public CourseService(IMapper mapper, IDatabaseSettings databaseSettings, MassTransit.IPublishEndpoint publishEndpoint)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);

        var database = client.GetDatabase(databaseSettings.DatabaseName);

        _courseCollection = database.GetCollection<Models.Course>(databaseSettings.CourseCollectionName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Response<List<CourseDTO>>> GetAllAsync()
    {
        var courses = await _courseCollection.Find(course => true).ToListAsync();

        if (courses.Any())
        {
            foreach (var course in courses)
            {
                course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();
            }
        }
        else
        {
            courses = new List<Models.Course>();
        }

        return Response<List<CourseDTO>>.Success(_mapper.Map<List<CourseDTO>>(courses), 200);
    }
    public async Task<Response<CourseDTO>> GetByIdAsync(string id)
    {
        var course = await _courseCollection.Find<Models.Course>(x => x.Id == id).FirstOrDefaultAsync();
        if (course == null)
        {
            return Response<CourseDTO>.Fail("Course not found", 404);
        }
        course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();

        return Response<CourseDTO>.Success(_mapper.Map<CourseDTO>(course), 200);
    }
    public async Task<Response<List<CourseDTO>>> GetAllUserIdAsync(string userId)
    {
        var courses = await _courseCollection.Find(x => x.UserId == userId).ToListAsync();

        if (courses.Any())
        {
            foreach (var course in courses)
            {
                course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();
            }
        }
        else
        {
            courses = new List<Models.Course>();
        }
        return Response<List<CourseDTO>>.Success(_mapper.Map<List<CourseDTO>>(courses), 200);

    }
    public async Task<Response<CourseDTO>> CreateAsync(CourseCreateDTO courseCreateDTO)
    {
        var newCourse = _mapper.Map<Models.Course>(courseCreateDTO);

        newCourse.CreatedTime = DateTime.Now;
        await _courseCollection.InsertOneAsync(newCourse);

        return Response<CourseDTO>.Success(_mapper.Map<CourseDTO>(newCourse), 200);
    }
    public async Task<Response<NoContent>> UpdateAsync(CourseUpdateDTO courseUpdateDTO)
    {
        var updateCourse = _mapper.Map<Models.Course>(courseUpdateDTO);

        var result = await _courseCollection.FindOneAndReplaceAsync(x => x.Id == courseUpdateDTO.Id, updateCourse);

        if (result == null)
        {
            return Response<NoContent>.Fail("Course not found", 404);
        }

        await _publishEndpoint.Publish<CourseNameChangedEvent>(new CourseNameChangedEvent
        {
            CourseId = updateCourse.Id,
            UpdatedName = courseUpdateDTO.Name
        });
        return Response<NoContent>.Success(204);
    }
    public async Task<Response<NoContent>> DeleteAsync(string id)
    {
        var result = await _courseCollection.DeleteOneAsync(x => x.Id == id);
        if (result.DeletedCount > 0)
        {
            return Response<NoContent>.Success(204);
        }
        return Response<NoContent>.Fail("Course not found", 404);
    }
}
