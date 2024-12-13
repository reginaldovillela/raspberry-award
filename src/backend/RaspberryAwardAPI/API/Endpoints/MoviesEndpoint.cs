using RaspberryAwardAPI.Application.Movies.Dtos;
using RaspberryAwardAPI.Application.Movies.Queries;
using RaspberryAwardAPI.Application.Shared.Dtos;
using RaspberryAwardAPI.Application.Shared.Results;

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

        api.MapGet("/", GetMoviesAsync);
        api.MapGet("/years-with-winners", GetYearsWithWinnersAsync);
    }

    private static async Task<Results<
        Ok<PagedResult<MovieSharedWithStudiosAndProducersDto>>,
        NotFound,
        BadRequest<string>>> GetMoviesAsync([AsParameters] GetMoviesQuery query,
                                            [AsParameters] MoviesEndpointServices services)
    {
        try
        {
            var movies = await services.Mediator.Send(query);

            return TypedResults.Ok(movies);
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

    private static async Task<Results<
        Ok<IEnumerable<YearWithWinnerDto>>,
        NotFound,
        BadRequest<string>>> GetYearsWithWinnersAsync([AsParameters] GetYearsWithWinnersQuery query,
                                                      [AsParameters] MoviesEndpointServices services)
    {
        try
        {
            var years = await services.Mediator.Send(query);

            return TypedResults.Ok(years);
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }
}