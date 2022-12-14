namespace Azox.XQR.Persistence.Mapping
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Text.Json;

    internal class MerchantMapping :
        EntityMappingBase<Merchant>
    {
        public override void Configure(EntityTypeBuilder<Merchant> builder, int lastColumnOrder)
        {
            builder.Property(x => x.MerchantType)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.Property(x => x.Address)
                .HasColumnOrder(lastColumnOrder++)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<Address>(v, (JsonSerializerOptions)null))
                .IsRequired(false);

            builder.Property(x => x.Contact)
                .HasColumnOrder(lastColumnOrder++)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<Contact>(v, (JsonSerializerOptions)null))
                .IsRequired(false);

            builder.Property(x => x.Picture)
                .HasColumnOrder(lastColumnOrder++)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<Picture>(v, (JsonSerializerOptions)null))
                .IsRequired(false);

            builder.Property(x => x.FacebookLink)
                .HasColumnOrder(lastColumnOrder++)
                .HasMaxLength(1024);

            builder.Property(x => x.InstagramLink)
                .HasColumnOrder(lastColumnOrder++)
                .HasMaxLength(1024);
        }
    }
}
