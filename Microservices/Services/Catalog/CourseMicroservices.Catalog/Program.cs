using CourseMicroservices.Catalog.DTOs;
using CourseMicroservices.Catalog.Services;
using CourseMicroservices.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerURL"];
    opt.Audience = "resource_catalog";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    var categoryService = serviceProvider.GetRequiredService<ICategoryService>();

    if (!(await categoryService.GetAllAsync()).Data.Any())
    {
        //await categoryService.CreateAsync(new CategoryCreateDTO { Name = "Asp.net Core Kursu" });
        //await categoryService.CreateAsync(new CategoryCreateDTO { Name = "Asp.net Core API Kursu" });

        await categoryService.CreateAsync(new CategoryDTO { Name = "Asp.net Core Kursu" });
        await categoryService.CreateAsync(new CategoryDTO { Name = "Asp.net Core API Kursu" });
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
