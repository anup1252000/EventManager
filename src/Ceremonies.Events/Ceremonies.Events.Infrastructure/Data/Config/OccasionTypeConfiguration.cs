namespace Ceremonies.Events.Infrastructure.Data.Config
{
    internal class OccasionTypeConfiguration : IEntityTypeConfiguration<Occasion>
    {
        public void Configure(EntityTypeBuilder<Occasion> builder)
        {
            builder.Property(x => x.Description).HasColumnType("VarChar(Max)");
        }
    }
}
