using RaspberryAwardAPI.Application.Movies.Dtos;
using RaspberryAwardAPI.Application.Movies.Queries;
using RaspberryAwardAPI.Domain.Movies;

namespace RaspberryAwardAPI.API.Endpoints;

#pragma warning disable 1591
internal class MoviesEndpointServices(IMediator mediator,
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

    private static async Task<Results<Ok<MovieDto[]>,
                              NotFound,
                              BadRequest<string>>> GetMoviesAsync([AsParameters] MoviesEndpointServices services)
    {
        try
        {
            var query = new GetMoviesQuery();
            var movies = await services.Mediator.Send(query);

            return TypedResults.Ok(movies);
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }
}

public record ProducerT(string Name);

public record MovieT(string Title, IList<ProducerT> Producers);
