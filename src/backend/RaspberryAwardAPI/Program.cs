using RaspberryAwardAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.AddDefaultServices();
builder.AddApplicationServices();

var app = builder.Build();

app.ConfigureDefaults();
app.AddEndpoints();

await app.RunAsync();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
