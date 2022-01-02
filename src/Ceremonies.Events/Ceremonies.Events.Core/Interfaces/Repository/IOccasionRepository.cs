namespace Ceremonies.Events.Core.Interfaces.Repository
{
    public interface IOccasionRepository
    {
        IQueryable<Occasion> GetOccasions(string city, DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
    }
}
