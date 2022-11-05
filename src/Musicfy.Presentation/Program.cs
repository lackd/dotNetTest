using System.Reflection;
using Musicfy.Core.Exceptions;
using Musicfy.Domain.Repository;
using Musicfy.Persistance.Data;
using Musicfy.Persistance.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Musicfy.Application.Query.Album.GetAlbum;
using Musicfy.Application.Command.Album.PostAlbum;
using Musicfy.Application.Query.Album.GetAlbums;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {

        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Musicfy API",
            Description = "Musicfy test",           
            License = new OpenApiLicense
            {
                Name = "MIT License",
                Url = new Uri("https://opensource.org/licenses/MIT")
            }
        });

        // using System.Reflection;
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

builder.Services.AddDbContext<MusicfyContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}
);
//Add mappers
builder.Services.AddAutoMapper(typeof(GetAlbumMapper),typeof(PostAlbumMapper));


//Add mediatR
builder.Services.AddMediatR(
    typeof(GetAlbumHandler));

//Add repositories
builder.Services.AddTransient<IAlbumRepository, AlbumRepository>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() ||  app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
