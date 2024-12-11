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

            var studios = FindAndInsertStudios(line, raspberryAwardContext);
            var producers = FindAndInsertProducers(line, raspberryAwardContext);
            
            FindInsertMovie(line, raspberryAwardContext, studios, producers);
        }

        raspberryAwardContext.SaveChanges();
    }

    private static string[] ReadData()
    {
        return File.ReadAllLines("./Assets/data.csv");
    }

    private static List<Studio> FindAndInsertStudios(string line, RaspberryAwardContext context)
    {
        var splitLine = line.Split(';');
        var name = splitLine[2];
        var studios = name.Split([",", "and"], StringSplitOptions.None);
        var studioList = new List<Studio>(studios.Length);

        foreach (var studio in studios)
        {
            var studioObject = context.Studios.Where(s => s.Name == studio).FirstOrDefault();

            if (studioObject is not null)
                studioList.Add(studioObject);
            else
            {
                var newstudio = new Studio(studio);
                context.Studios.Add(newstudio);
                studioList.Add(newstudio);
            }
        }

        return studioList;
    }

    private static List<Producer> FindAndInsertProducers(string line, RaspberryAwardContext context)
    {
        var splitLine = line.Split(';');
        var name = splitLine[3];
        var producers = name.Split([",", "and"], StringSplitOptions.None);
        var producerList = new List<Producer>(producers.Length);

        foreach (var producer in producers)
        {
            var produceObject = context.Producers.Where(s => s.Name == producer).FirstOrDefault();

            if (produceObject is not null)
                producerList.Add(produceObject);
            else
                {
                var newProducer = new Producer(producer);
                context.Producers.Add(newProducer);
                producerList.Add(newProducer);
            }
        }

        return producerList;
    }

    private static void FindInsertMovie(string line, RaspberryAwardContext context, List<Studio> studios, List<Producer> producers)
    {
        var splitLine = line.Split(';');
        var year = ushort.Parse(splitLine[0]);
        var title = splitLine[1];
        var winner = splitLine[4] == "yes";

        var movie = new Movie(title, year, winner);
        movie.AddStudios(studios);
        movie.AddProducers(producers);

        context.Movies.Add(movie);
    }

    [GeneratedRegex(@"^\d{4}")]
    private static partial Regex StartWithNumbers();
}