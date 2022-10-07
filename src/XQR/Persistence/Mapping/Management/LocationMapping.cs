namespace Azox.XQR.Persistence.Mapping
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class LocationMapping :
        EntityMappingBase<Location>
    {
        public override void Configure(EntityTypeBuilder<Location> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.Service)
                .WithMany(x => x.Locations)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(x => x.Slug)
                .HasMaxLength(1024)
                .IsRequired();
        }
    }
}
