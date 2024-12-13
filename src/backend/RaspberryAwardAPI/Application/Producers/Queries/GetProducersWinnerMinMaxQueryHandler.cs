using RaspberryAwardAPI.Application.Producers.Dtos;
using RaspberryAwardAPI.Domain.Producers;

namespace RaspberryAwardAPI.Application.Producers.Queries;

#pragma warning disable 1591
public class GetProducersWinnerMinMaxQueryHandler(
    ILogger<GetProducersWinnerMinMaxQueryHandler> logger,
    IProducersRepository repository) : IRequestHandler<GetProducersWinnerMinMaxQuery, ProducersWinnerMinMax>
{
    public async Task<ProducersWinnerMinMax> Handle(GetProducersWinnerMinMaxQuery request, CancellationToken cancellationToken)
    {
        var producers = await repository.GetAllAlreadyWinnerAsync(cancellationToken);

        logger.LogInformation("Consulta concluída. Total de {@count} encontrados", producers.Count());

        var producerShort = FindProducerMinWin(producers);
        var producerMax = FindProducerMaxWin(producers);

        return new ProducersWinnerMinMax(producerShort, producerMax);
    }

    private static ProducerWinnner FindProducerMinWin(IEnumerable<Producer> producers)
    {
        var currentProducerName = string.Empty;
        var currentInterval = (ushort)1000;
        var currentPreviousYear = (ushort)1900;
        var currentFollowingYear = (ushort)1900;

        foreach (var producer in producers)
        {
            // venceu apenas uma vez
            if (producer.Movies.Count <= 1)
                continue;

            // recupera os dois primeiros filmes
            var movies = producer.Movies.OrderBy(m => m.Year).ToList();

            for (var i = 1; i < movies.Count; i++)
            {
                var firstYear = movies[i - 1].Year;
                var secondYear = movies[i].Year;
                var interval = secondYear - firstYear;

                if (interval < currentInterval)
                {
                    currentProducerName = producer.Name;
                    currentPreviousYear = firstYear;
                    currentFollowingYear = secondYear;
                    currentInterval = (ushort)interval;
                }
            }
        }

        return new ProducerWinnner(currentProducerName,
                                   currentInterval,
                                   currentPreviousYear,
                                   currentFollowingYear);

        // var currentInterval = (ushort)1000;
        // var currentPreviousYear = (ushort)1900;
        // var currentFollowingYear = (ushort)1900;
        // Producer? currentProducer = null;

        // foreach (var producer in producers)
        // {
        //     // venceu apenas uma vez
        //     if (producer.Movies.Count <= 1)
        //         continue;

        //     // recupera os dois primeiros filmes
        //     var movies = producer
        //         .Movies
        //         .OrderBy(m => m.Year)
        //         .Take(2)
        //         .ToArray();

        //     // compara os anos dos filmes
        //     var interval = movies[1].Year - movies[0].Year;

        //     if (interval >= currentInterval)
        //         continue;

        //     currentProducer = producer;
        //     currentInterval = (ushort)interval;
        //     currentPreviousYear = movies[0].Year;
        //     currentFollowingYear = movies[1].Year;
        // }

        // return new ProducerWinnner(currentProducer!.Name,
        //                            currentInterval,
        //                            currentPreviousYear,
        //                            currentFollowingYear);
    }

    private static ProducerWinnner FindProducerMaxWin(IEnumerable<Producer> producers)
    {
        var currentProducerName = string.Empty;
        var currentInterval = (ushort)0;
        var currentPreviousYear = (ushort)1900;
        var currentFollowingYear = (ushort)1900;

        foreach (var producer in producers)
        {
            // venceu apenas uma vez
            if (producer.Movies.Count <= 1)
                continue;

            // recupera os dois primeiros filmes
            var movies = producer.Movies.OrderBy(m => m.Year).ToList();

            for (var i = 1; i < movies.Count; i++)
            {
                var firstYear = movies[i - 1].Year;
                var secondYear = movies[i].Year;
                var interval = secondYear - firstYear;

                if (interval > currentInterval)
                {
                    currentProducerName = producer.Name;
                    currentPreviousYear = firstYear;
                    currentFollowingYear = secondYear;
                    currentInterval = (ushort)interval;
                }
            }
        }

        return new ProducerWinnner(currentProducerName,
                                   currentInterval,
                                   currentPreviousYear,
                                   currentFollowingYear);
    }
}