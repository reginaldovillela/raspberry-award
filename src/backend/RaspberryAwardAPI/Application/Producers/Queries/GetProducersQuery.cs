using RaspberryAwardAPI.Application.Producers.Dtos;

namespace RaspberryAwardAPI.Application.Producers.Queries;

#pragma warning disable 1591
public record GetProducersQuery : IRequest<IEnumerable<ProducerDto>>;