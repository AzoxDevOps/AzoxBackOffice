namespace Azox.XQR.Persistence.Mapping.Region
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Region;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CityMapping :
        EntityMappingBase<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder, int lastColumnOrder)
        {
            builder.Property(x => x.Code)
                .HasColumnOrder(lastColumnOrder++)
                .HasMaxLength(1024)
                .IsRequired();
        }
    }
}
