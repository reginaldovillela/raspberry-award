using RaspberryAwardAPI.Domain.Producers;

namespace RaspberryAwardAPI.API.Endpoints;

#pragma warning disable 1591
internal class ProducersEndpointServices(IMediator mediator,
                                         ILogger<ProducersEndpointServices> logger)
{
    public IMediator Mediator { get; set; } = mediator;

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

        api.MapGet("/", GetProducersAsync)
           .ProducesProblem((int)HttpStatusCode.NotAcceptable);
    }

    private static async Task<Results<Ok<Producer[]>,
                              NotFound,
                              BadRequest<string>>> GetProducersAsync([AsParameters] ProducersEndpointServices services)
    {
        // try
        // {
        //     var query = new GetMoviesQuery();
        //     var movies = await services.Mediator.Send(query);
        //     
        //     return TypedResults.Ok(movies);
        // }
        // catch (Exception ex)
        // {
        //     return TypedResults.BadRequest(ex.Message);
        // }
        return null;
    }
}
