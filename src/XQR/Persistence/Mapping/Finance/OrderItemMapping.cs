namespace Azox.XQR.Persistence.Mapping.Finance
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Order;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class OrderItemMapping :
        EntityMappingBase<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.Order)
                .WithMany(x => x.Items)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(x => x.Note)
                .HasColumnOrder(lastColumnOrder++)
                .HasMaxLength(4000);
        }
    }
}
