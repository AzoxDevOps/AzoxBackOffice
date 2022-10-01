namespace Azox.XQR.Persistence.Mapping
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Text.Json;

    internal class OrderItemMapping :
        EntityMappingBase<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.Order)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(x => x.UnitPrice)
                .HasColumnOrder(lastColumnOrder++)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<Price>(v, (JsonSerializerOptions)null))
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired();
        }
    }
}
