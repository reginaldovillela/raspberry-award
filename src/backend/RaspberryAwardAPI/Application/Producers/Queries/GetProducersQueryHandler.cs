using RaspberryAwardAPI.Application.Producers.Dtos;
using RaspberryAwardAPI.Domain.Producers;

namespace RaspberryAwardAPI.Application.Producers.Queries;

#pragma warning disable 1591
public class GetProducersQueryHandler(
    ILogger<GetProducersQueryHandler> logger,
    IProducersRepository repository) : IRequestHandler<GetProducersQuery, IEnumerable<ProducerDto>>
{
    public async Task<IEnumerable<ProducerDto>> Handle(GetProducersQuery request, CancellationToken cancellationToken)
    {
        var producers = await repository.GetProducersAsync(cancellationToken);

        logger.LogInformation("Consulta concluída. Total de {@count} encontrados", producers.Count());
        
        return producers.Select(p => new ProducerDto(p.EntityId, p.Name));
    }
}