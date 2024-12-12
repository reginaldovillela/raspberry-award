using RaspberryAwardAPI.Application.Producers.Dtos;
using RaspberryAwardAPI.Application.Producers.Queries;

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
        api.MapGet("/short-winner", GetProducersShortWinnerAsync);
    }

    private static async Task<Results<Ok<IEnumerable<ProducerDto>>,
                              NotFound,
                              BadRequest<string>>> GetProducersAsync([AsParameters] ProducersEndpointServices services)
    {
        try
        {
            var query = new GetProducersQuery();
            var producers = await services.Mediator.Send(query);
            
            return TypedResults.Ok(producers);
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }
    
    private static async Task<Results<Ok<object>,
        NotFound,
        BadRequest<string>>> GetProducersShortWinnerAsync([AsParameters] ProducersEndpointServices services)
    {
        try
        {
            var query = new GetProducersShortWinnerQuery();
            var producers = await services.Mediator.Send(query);
            
            return TypedResults.Ok(producers);
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }
}
