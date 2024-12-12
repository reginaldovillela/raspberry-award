using System.Reflection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RaspberryAwardAPI.Domain.Movies;
using RaspberryAwardAPI.Domain.Producers;
using RaspberryAwardAPI.Domain.Studios;
using RaspberryAwardAPI.Infrastructure;

namespace RaspberryAwardAPI.API.Extensions;

internal static class ServiceExtensions
{
    public static void AddDefaultServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;

        services
            .AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

        services.AddCors();
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(config =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            config.CustomSchemaIds(x => x.FullName);
            // config.CustomSchemaIds(x => x.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName
            //                          ?? x.DefaultSchemaIdSelector());
        });

        services.Configure<ApiBehaviorOptions>(config => { config.SuppressInferBindingSourcesForParameters = true; });
    }

    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        //var config = builder.Configuration;

        // mediatr
        services.AddMediatR(opt => { opt.RegisterServicesFromAssemblyContaining<Program>(); });

        services.AddValidatorsFromAssemblyContaining<Program>();

        services.AddDbContext<RaspberryAwardContext>(opt => { opt.UseInMemoryDatabase("RaspberryAwardDB"); });

        services.AddScoped<IMoviesRepository, MoviesRepository>();
        services.AddScoped<IProducersRepository, ProducersRepository>();
        services.AddScoped<IStudiosRepository, StudiosRepository>();
        services.AddScoped<RaspberryAwardContext>();
    }
}