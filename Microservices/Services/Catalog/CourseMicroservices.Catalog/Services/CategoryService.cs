﻿using AutoMapper;
using Course.Shared.DTOs;
using CourseMicroservices.Catalog.DTOs;
using CourseMicroservices.Catalog.Models;
using CourseMicroservices.Catalog.Settings;
using MongoDB.Driver;

namespace CourseMicroservices.Catalog.Services;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);

        var database = client.GetDatabase(databaseSettings.DatabaseName);

        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task<Response<List<CategoryDTO>>> GetAllAsync()
    {
        var categories = await _categoryCollection.Find(category => true).ToListAsync();
        return Response<List<CategoryDTO>>.Success(_mapper.Map<List<CategoryDTO>>(categories), 200);
    }
    public async Task<Response<CategoryDTO>> CreateAsync(CategoryCreateDTO categoryCreateDto)
    {
        var category = _mapper.Map<Category>(categoryCreateDto);
        await _categoryCollection.InsertOneAsync(category);

        return Response<CategoryDTO>.Success(_mapper.Map<CategoryDTO>(category), 200);
    }


    public async Task<Response<CategoryDTO>> GetByIdAsync(string id)
    {
        var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();

        if (category == null)
        {
            return Response<CategoryDTO>.Fail("Category not found", 404);
        }
        return Response<CategoryDTO>.Success(_mapper.Map<CategoryDTO>(category), 200);
    }
}
