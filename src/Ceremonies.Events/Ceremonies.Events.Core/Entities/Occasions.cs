namespace Ceremonies.Events.Core.Entities
{
    public class Occasion:AuditableEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? About { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? FeatureImageUrl { get; set; }

        public int ImageId { get; set; }

        public string? AgeLimit { get; set; }

        public bool IsPhysicalEvent { get; set; }

        public bool IsVirtualEvent { get; set; }

        public string? City { get; set; }
    }

}
