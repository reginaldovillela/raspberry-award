using RaspberryAwardAPI.Application.Shared.Dtos;
using RaspberryAwardAPI.Application.Shared.Queries;
using RaspberryAwardAPI.Application.Shared.Results;

namespace RaspberryAwardAPI.Application.Producers.Queries;

#pragma warning disable 1591
public class GetProducersQuery 
    : PagedQuery,
    IRequest<PagedResult<ProducerSharedDto>>;