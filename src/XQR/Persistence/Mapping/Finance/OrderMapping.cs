namespace Azox.XQR.Persistence.Mapping
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class OrderMapping :
        EntityMappingBase<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.Location)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
