using EstudoRest.Model.Context;
using EstudoRest.Business;
using EstudoRest.Business.Implementations;
using Microsoft.EntityFrameworkCore;
using EstudoRest.Repository;
using Serilog;
using MySqlConnector;
using EstudoRest.Repository.Generic;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();


// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

// opção de ser consumida via XML também
builder.Services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
}).AddXmlSerializerFormatters();

//versioning api
builder.Services.AddApiVersioning();

//Scopo da API
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


void MigrateDatabase(string connection)
{
    try
    {
        var evolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };

        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration Failed", ex);
        throw;
    }
}


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
