namespace Azox.XQR.Persistence.Mapping.Region
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Region;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class DistrictMapping :
        EntityMappingBase<District>
    {
        public override void Configure(EntityTypeBuilder<District> builder, int lastColumnOrder)
        {
            builder.Property(x => x.Code)
                .HasColumnOrder(lastColumnOrder)
                .HasMaxLength(16);

            builder.HasOne(x => x.City)
                .WithMany(x => x.Districts)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
