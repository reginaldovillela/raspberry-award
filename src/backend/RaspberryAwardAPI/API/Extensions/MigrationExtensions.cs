using System.Text.RegularExpressions;
using RaspberryAwardAPI.Domain.Movies;
using RaspberryAwardAPI.Domain.Producers;
using RaspberryAwardAPI.Domain.Studios;
using RaspberryAwardAPI.Infrastructure;

namespace RaspberryAwardAPI.API.Extensions;

internal static partial class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var data = ReadData();

        using var raspberryAwardContext = scope.ServiceProvider.GetRequiredService<RaspberryAwardContext>();
        //raspberryAwardContext.Database.Migrate();
        raspberryAwardContext.Database.EnsureCreated();
        
        foreach (var line in data)
        {
            if (!StartWithNumbers().IsMatch(line))
                continue;

            var studio = CreateStudio(line);
            var producers = GetProducers(line);
            var movie = CreateMovie(line);

            raspberryAwardContext.Producers.AddRange(producers);
            
            foreach (var producer in producers)
                movie.AddProducer(producer);
            
            raspberryAwardContext.Movies.Add(movie);
        }

        raspberryAwardContext.SaveChanges();
    }

    private static string[] ReadData()
    {
        return File.ReadAllLines("./Assets/data.csv");
    }

    private static Studio CreateStudio(string line)
    {
        var splitLine = line.Split(';');
        var name = splitLine[2];
        return new Studio(name);
    }
    
    private static Producer[] GetProducers(string line)
    {
        var splitLine = line.Split(';');
        var name = splitLine[3];
        var producers = name.Split([",", "and"], StringSplitOptions.None);
        return producers.Select(x=> new Producer(x)).ToArray();
        //return new Producer(name);
    }
    
    private static Movie CreateMovie(string line)
    {
        var splitLine = line.Split(';');
        var year = ushort.Parse(splitLine[0]);
        var title = splitLine[1];
        var winner  = splitLine[4] == "yes";
        return new Movie(title, year, winner);
    }

    [GeneratedRegex(@"^\d{4}")]
    private static partial Regex StartWithNumbers();
}