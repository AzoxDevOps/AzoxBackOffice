namespace Azox.XQR.Persistence.Mapping.Finance
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Order;
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

            builder.Property(x => x.Note)
                .HasColumnOrder(lastColumnOrder++)
                .HasMaxLength(4000);
        }
    }
}
