using Microsoft.AspNetCore.Mvc;
using UnitsConversionModule.Converters;
using UnitsConversionModule.Converters.Interfaces;
using UnitsConversionModule.Middleware;
using UnitsConversionModule.Services;
using UnitsConversionModule.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IConversionService,ConversionService>();
builder.Services.AddScoped<IUnitConverter, LengthConverter>();
builder.Services.AddScoped<IUnitConverter, WeightConverter>();
builder.Services.AddScoped<IUnitConverter, VolumeConverter>();
builder.Services.AddScoped<IUnitConverter, TemperatureConverter>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        var response = new
        {
            error = "Validation failed.",
            details = errors
        };

        return new BadRequestObjectResult(response);
    };
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();