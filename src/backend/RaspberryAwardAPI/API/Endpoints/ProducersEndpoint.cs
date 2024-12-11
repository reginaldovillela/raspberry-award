using RaspberryAwardAPI.Domain.Studios;

namespace RaspberryAwardAPI.API.Endpoints;

#pragma warning disable 1591
internal class StudiosEndpointServices(IMediator mediator,
                                         ILogger<StudiosEndpointServices> logger)
{
    public IMediator Mediator { get; set; } = mediator;

    public ILogger<StudiosEndpointServices> Logger { get; } = logger;
}

public static class StudiosEndpoint
{
    private const string TagEndpoint = "Studios";
    private const string BaseEndpoint = "studios";

    public static void MapStudiosEndpoint(this IEndpointRouteBuilder app)
    {
        var api = app
            .MapGroup(BaseEndpoint)
            .WithTags(TagEndpoint)
            .WithOpenApi();

        api.MapGet("/", GetStudiosAsync)
           .ProducesProblem((int)HttpStatusCode.NotAcceptable);
    }

    private static async Task<Results<Ok<Studio[]>,
                              NotFound,
                              BadRequest<string>>> GetStudiosAsync([AsParameters] StudiosEndpointServices services)
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
