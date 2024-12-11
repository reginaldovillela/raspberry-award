using RaspberryAwardAPI.Domain.Movies;

namespace RaspberryAwardAPI.Application.Movies.Queries;

#pragma warning disable 1591
public record GetMoviesQuery: IRequest<Movie[]>;