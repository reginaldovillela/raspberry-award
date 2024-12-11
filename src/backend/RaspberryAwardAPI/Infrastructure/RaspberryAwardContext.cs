using RaspberryAwardAPI.Domain.Movies;
using RaspberryAwardAPI.Domain.Producers;
using RaspberryAwardAPI.Domain.SeedWork.Interfaces;
using RaspberryAwardAPI.Domain.Studios;

namespace RaspberryAwardAPI.Infrastructure;

#pragma warning disable 1591
public class RaspberryAwardContext(DbContextOptions<RaspberryAwardContext> options) 
    : DbContext(options), IUnitOfWork
{
    public DbSet<Movie> Movies { get; init; }
    
    public DbSet<Studio> Studios { get; init; }
    
    public DbSet<Producer> Producers { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasMany(x=> x.Producers)
            .WithMany(p=> p.Movies);

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        _ = await base.SaveChangesAsync(cancellationToken);

        return true;
    }
}