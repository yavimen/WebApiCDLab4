using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi.Extentions;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.CorsConfig(builder.Configuration);

builder.Services.AddDataServices();

builder.Services.AddControllers().
    AddControllersAsServices()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<MedicalHistoriesContext>( options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDbContext"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Origins");

app.UseAuthorization();

app.MapControllers();

app.Run();
