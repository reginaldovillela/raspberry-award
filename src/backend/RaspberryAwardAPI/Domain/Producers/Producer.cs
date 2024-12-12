using System.ComponentModel.DataAnnotations.Schema;
using RaspberryAwardAPI.Domain.Movies;
using RaspberryAwardAPI.Domain.SeedWork;
using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Domain.Producers;

#pragma warning disable 1591

[Index(nameof(Name), IsUnique = true)]
[Table("producers")]
public class Producer
    : Entity, IAggregateRoot
{
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Name { get; private set; }
    
    public List<Movie> Movies { get; private set; }
    
    #region "ef requirements and relations"

#pragma warning disable CS8618
    protected Producer() { }
#pragma warning restore CS8618

    #endregion
    
    public Producer(string name)
    {
        Name = name;
        Movies = [];
    }

    public void AddMovie(Movie movie)
    {
        Movies.Add(movie);
    }
    
    public void AddMovies(params Movie[] movies)
    {
        Movies.AddRange(movies);
    }
}