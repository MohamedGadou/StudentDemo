using Microsoft.EntityFrameworkCore;
using StudentDemo.Application.Services;
using StudentDemo.Domain.IRepos;
using StudentDemo.Domain.IService;
using StudentDemo.Infrastructure.Context;
using StudentDemo.Infrastructure.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Should be moved to extension methods
// Please Note that the refernce to Infrastructur dll is not a best practice as it can pass the service layer and inject db context directly
// so the registeration of db context should be isloated from presentation layer
builder.Services.AddDbContext<StudentDemoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
