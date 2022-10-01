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
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
