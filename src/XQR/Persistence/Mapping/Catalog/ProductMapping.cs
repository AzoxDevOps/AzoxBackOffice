namespace Azox.XQR.Persistence.Mapping.Catalog
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Catalog;
    using Azox.XQR.Business.Domain.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Text.Json;

    internal class ProductMapping :
        EntityMappingBase<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder, int lastColumnOrder)
        {
            builder.Property(x => x.IsVisible)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.Property(x => x.DisplayOrder)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnOrder(lastColumnOrder++)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<Price>(v, (JsonSerializerOptions)null))
                .IsRequired();

            builder.Property(x => x.OldPrice)
                .HasColumnOrder(lastColumnOrder++)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<Price>(v, (JsonSerializerOptions)null))
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
