using EstudoRest.Model.Context;
using EstudoRest.Services;
using EstudoRest.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.



builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, null));

builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
