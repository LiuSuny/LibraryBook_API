using LibraryBook_TaskAPI.Data;
using LibraryBook_TaskAPI.Helpers;
using LibraryBook_TaskAPI.Interface;
using LibraryBook_TaskAPI.MediatorHandlerService;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//injecting mediatr
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<LibraryBookContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IAuthorRepository, AuthorCommandService>();
builder.Services.AddScoped<IBookRepository, BookCommandHandler>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
