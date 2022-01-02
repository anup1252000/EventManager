namespace Ceremonies.Events.Core.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Occasion> Occasions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
