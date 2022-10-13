using EstudoRest.Model.Context;
using EstudoRest.Business;
using EstudoRest.Business.Implementations;
using Microsoft.EntityFrameworkCore;
using EstudoRest.Repository;
using EstudoRest.Repository.Implementations;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));


//versioning api
builder.Services.AddApiVersioning();

//Scopo da API
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();




var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
