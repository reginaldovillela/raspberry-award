using RaspberryAwardAPI.Domain.Producers;

namespace RaspberryAwardAPI.Application.Producers.Queries;

#pragma warning disable 1591
public class GetProducersShortWinnerQueryHandler(
    ILogger<GetProducersShortWinnerQueryHandler> logger,
    IProducersRepository repository) : IRequestHandler<GetProducersShortWinnerQuery, object>
{
    public async Task<object> Handle(GetProducersShortWinnerQuery request, CancellationToken cancellationToken)
    {
        var producers = await repository.GetAllAlreadyWinnerAsync(cancellationToken);

        logger.LogInformation("Consulta concluída. Total de {@count} encontrados", producers.Count());

        var producer = FindProducer(producers);

        return new
        {
            Id = producer.EntityId,
            producer.Name,
            Movies = producer.Movies.Select(movie => new
            {
                Id = movie.EntityId,
                movie.Title,
                movie.Year
            }),
        };
    }

    private static Producer FindProducer(IEnumerable<Producer> producers)
    {
        var currentInterval = 1000;
        Producer? currentProducer = null;

        foreach (var producer in producers)
        {
            // recupera os dois primeiros filmes
            var movies = producer.Movies.OrderBy(m => m.Year).Take(2).ToArray();

            // compora os anos dos filmes
            var interval = movies[1].Year - movies[0].Year;

            if (interval >= currentInterval)
                continue;

            currentProducer = producer;
            currentInterval = interval;
        }

        return currentProducer!;
    }
}