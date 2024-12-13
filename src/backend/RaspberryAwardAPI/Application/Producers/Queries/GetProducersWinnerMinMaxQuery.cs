using RaspberryAwardAPI.Application.Producers.Dtos;

namespace RaspberryAwardAPI.Application.Producers.Queries;

#pragma warning disable 1591

public record ProducersWinnerMinMax(ProducerWinnner Min, ProducerWinnner Max);

public class GetProducersWinnerMinMaxQuery : IRequest<ProducersWinnerMinMax>;