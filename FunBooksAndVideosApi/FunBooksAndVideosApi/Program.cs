using FunBooksAndVideos.Data;
using FunBooksAndVideos.Processor;
using FunBooksAndVideos.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<BookAndVideoContext>(options => options.UseSqlServer(configuration.GetConnectionString("FunBooksAndVideosDb")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDataInstances();
builder.Services.RegisterServiceInstances();
builder.Services.RegisterProcessorInstances();

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

/// <summary>
/// Added to Make FunctionalTest Compile
/// </summary>
public partial class Program { }
