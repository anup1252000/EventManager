namespace Ceremonies.Events.Infrastructure.Data.Repository
{
    public class OccasionRepository : IOccasionRepository
    {
        #region Fields
        private readonly IApplicationDbContext _applicationDbContext;
        #endregion

        #region Constructor
        public OccasionRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #endregion

        #region Methods
        public  IQueryable<Occasion> GetOccasions(string city, DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            return  _applicationDbContext.Occasions.Where(x => x.City == city && x.StartDate == startDate && x.EndDate == endDate);
        }
        #endregion
    }
}
