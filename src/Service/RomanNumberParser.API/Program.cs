using RomanParser.Core;
using RomanParser.Core.Contract;
using RomanParser.Core.Parser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IValueValidator, RomanValueValidator>();
builder.Services.AddScoped<IValueValidator, DecimalValueValidator>();
builder.Services.AddScoped<IRomanNumberSumCalculator, RomanNumberSumCalculator>();
builder.Services.AddScoped<IInterpreter, DecimalToRomanInterpreter>();



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
