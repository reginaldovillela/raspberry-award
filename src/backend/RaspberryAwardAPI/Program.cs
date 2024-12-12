using RaspberryAwardAPI.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddDefaultServices();
builder.AddApplicationServices();

var app = builder.Build();

app.ConfigureDefaults();
app.AddEndpoints();

await app.RunAsync();