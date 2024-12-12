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
            raspberryAwardContext.SaveChanges();
        }
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
            var studioName = studio.Trim();

            if (string.IsNullOrWhiteSpace(studioName))
                continue;

            var studioObject = context.Studios.FirstOrDefault(s => s.Name == studioName);

            if (studioObject is not null)
                studioList.Add(studioObject);
            else
            {
                var newStudio = new Studio(studioName);
                context.Studios.Add(newStudio);
                //context.SaveChanges();
                studioList.Add(newStudio);
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
            var producerName = producer.Trim();

            if (string.IsNullOrEmpty(producerName))
                continue;

            var produceObject = context.Producers.FirstOrDefault(s => s.Name == producerName);

            if (produceObject is not null)
                producerList.Add(produceObject);
            else
            {
                var newProducer = new Producer(producerName);
                context.Producers.Add(newProducer);
                //context.SaveChanges();
                producerList.Add(newProducer);
            }
        }

        return producerList;
    }

    private static void FindInsertMovie(string line, RaspberryAwardContext context, List<Studio> studios,
        List<Producer> producers)
    {
        var splitLine = line.Split(';');
        var year = ushort.Parse(splitLine[0]);
        var title = splitLine[1];
        var winner = splitLine[4] == "yes";

        var movie = new Movie(title, year, winner);
        movie.AddStudios(studios.ToArray());
        movie.AddProducers(producers.ToArray());

        context.Movies.Add(movie);
    }

    [GeneratedRegex(@"^\d{4}")]
    private static partial Regex StartWithNumbers();
}