using RaspberryAwardAPI.Application.Shared.Dtos;
using RaspberryAwardAPI.Application.Studios.Dtos;
using RaspberryAwardAPI.Application.Studios.Queries;

namespace RaspberryAwardAPI.API.Endpoints;

#pragma warning disable 1591
internal class StudiosEndpointServices(
    IMediator mediator,
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

        api.MapGet("/", GetStudiosAsync).ProducesProblem((int)HttpStatusCode.NotAcceptable);
        api.MapGet("/top-winners", GetTopWinnersStudiosAsync);
    }

    private static async Task<Results<
        Ok<IEnumerable<StudioSharedDto>>,
        NotFound,
        BadRequest<string>>> GetStudiosAsync([AsParameters] StudiosEndpointServices services)
    {
        try
        {
            var query = new GetStudiosQuery();
            var studios = await services.Mediator.Send(query);

            return TypedResults.Ok(studios);
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

    private static async Task<Results<
        Ok<IEnumerable<TopWinnerStudioDto>>,
        NotFound,
        BadRequest<string>>> GetTopWinnersStudiosAsync([AsParameters] GetTopWinnersStudiosQuery query,
                                                       [AsParameters] StudiosEndpointServices services)
    {
        try
        {
            var studios = await services.Mediator.Send(query);

            return TypedResults.Ok(studios);
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }
}