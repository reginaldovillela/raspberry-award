namespace RaspberryAwardAPI.Endpoints;

#pragma warning disable 1591
public class MoviesEndpointServices(IMediator mediator,
                                    ILogger<MoviesEndpointServices> logger)
{
    public IMediator Mediator { get; set; } = mediator;

    public ILogger<MoviesEndpointServices> Logger { get; } = logger;
}

public static class MoviesEndpoint
{
    private const string TagEndpoint = "Movies";
    private const string BaseEndpoint = "movies";

    public static void MapMoviesEndpoint(this IEndpointRouteBuilder app)
    {
        var api = app
            .MapGroup(BaseEndpoint)
            .WithTags(TagEndpoint)
            .WithOpenApi();

        api.MapGet("/", GetMoviesAsync)
           .ProducesProblem((int)HttpStatusCode.NotAcceptable);
    }

    private static async Task<Results<Ok<string>,
                              NotFound,
                              BadRequest<string>>> GetMoviesAsync([AsParameters] MoviesEndpointServices services)
    {
        return await Task.Run(() =>
        {
            try
            {
                return TypedResults.Ok("");
            }
            catch (Exception ex)
            {
                TypedResults.BadRequest(ex.Message);
            }

            return TypedResults.Ok("");
        });
    }
}
