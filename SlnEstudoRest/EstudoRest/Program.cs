using EstudoRest.Services.Implementations;
using EstudoRest.Services;
using EstudoRest.Model.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

var connection = builder.Configuration["SqlConnection:SqlConnectionString"];

builder.Services.AddDbContext<SqlContext>(options => options.UseMySql(connection));
   
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
