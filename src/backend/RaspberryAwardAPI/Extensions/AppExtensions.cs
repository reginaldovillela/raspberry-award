using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using RaspberryAwardAPI.Endpoints;

namespace RaspberryAwardAPI.Extensions;

internal static class AppExtensions
{
    public static void ConfigureDefaults(this WebApplication app)
    {
        app.UseHttpsRedirection();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapHealthChecks("/health");

            app.MapHealthChecks("/alive", new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("live")
            });
        }
    }

    public static void AddEndpoints(this WebApplication app)
    {
        app.MapMoviesEndpoint();
    }
}
