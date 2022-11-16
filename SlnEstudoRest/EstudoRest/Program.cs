using EstudoRest.Model.Context;
using EstudoRest.Business;
using EstudoRest.Business.Implementations;
using Microsoft.EntityFrameworkCore;
using EstudoRest.Repository;
using Serilog;
using MySqlConnector;
using EstudoRest.Repository.Generic;
using Microsoft.Net.Http.Headers;
using EstudoRest.HyperMedia.Filters;
using EstudoRest.HyperMedia.Enricher;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

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
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
}).AddXmlSerializerFormatters();

var filterOptions = new HyperMediaFilterOptions();

filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BookEnricher());

builder.Services.AddSingleton(filterOptions);

//Configure CORS    
builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));


//versioning api
builder.Services.AddApiVersioning();

//swagger
builder.Services.AddSwaggerGen(c => c.SwaggerDoc(
    "v1", new OpenApiInfo
    {
        Title = "REST API´s 0 to Azure ASP.NET Core 6 and Docker",
        Version = "v1",
        Description = "API RESTfull developed in course REST API´s 0 to Azure ASP.NET Core 6 and Docker",
        Contact = new OpenApiContact
        {
            Name = "Evirson Firoilo",
            Url = new Uri("https://github.com/evirson")
        }
    }));

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
        //throw;
    }
}


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");


/*Configurações de Swagger */
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API´s 0 to Azure ASP.NET Core 6 and Docker - v1");
});

var option = new RewriteOptions();

option.AddRedirect("^$", "swagger");

app.UseRewriter(option);
/*Fim Configurações de Swagger */

//habilitando CORS - Cross Origin Resource Sharing 
app.UseCors();

app.Run();
