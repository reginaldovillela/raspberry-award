using RaspberryAwardAPI.Application.Producers.Queries;
using RaspberryAwardAPI.Application.Shared.Dtos;
using RaspberryAwardAPI.Application.Shared.Results;

namespace RaspberryAwardAPI.API.Endpoints;

#pragma warning disable 1591
internal class ProducersEndpointServices(IMediator mediator,
                                         ILogger<ProducersEndpointServices> logger)
{
    public IMediator Mediator { get; } = mediator;

    public ILogger<ProducersEndpointServices> Logger { get; } = logger;
}

public static class ProducersEndpoint
{
    private const string TagEndpoint = "Producers";
    private const string BaseEndpoint = "producers";

    public static void MapProducersEndpoint(this IEndpointRouteBuilder app)
    {
        var api = app
            .MapGroup(BaseEndpoint)
            .WithTags(TagEndpoint)
            .WithOpenApi();

        api.MapGet("/", GetProducersAsync);
        api.MapGet("/min-max-winner", GetProducersMinMaxWinnerAsync);
    }

    private static async Task<Results<
        Ok<PagedResult<ProducerSharedDto>>,
        NotFound,
        BadRequest<string>>> GetProducersAsync([AsParameters] GetProducersQuery query,
                                               [AsParameters] ProducersEndpointServices services)
    {
        try
        {
            var producers = await services.Mediator.Send(query);

            return TypedResults.Ok(producers);
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

    private static async Task<Results<
        Ok<ProducersWinnerMinMax>,
        NotFound,
        BadRequest<string>>> GetProducersMinMaxWinnerAsync([AsParameters] ProducersEndpointServices services)
    {
        try
        {
            var query = new GetProducersWinnerMinMaxQuery();
            var producers = await services.Mediator.Send(query);

            return TypedResults.Ok(producers);
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }
}
