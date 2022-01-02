namespace Ceremonies.Events.Core.Services.Queries.GetOccasionByCity
{
    public class GetOccasionsQuery:IRequest<IEnumerable<OccasionDto>>
    {
        public string? City { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
