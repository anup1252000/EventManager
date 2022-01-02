namespace Ceremonies.Events.Core.Mappings.Profiles
{
    public class OccasionProfile:Profile
    {
        public OccasionProfile()
        {
            CreateMap<CreateOccasionsCommand, Occasion>();
        }
    }
}
