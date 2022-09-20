namespace Azox.XQR.Persistence.Mapping.Management
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Common;
    using Azox.XQR.Business.Domain.Management;
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

            builder.HasOne(x => x.Address)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.Picture)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Contact)
                .HasColumnOrder(lastColumnOrder++)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<Contact>(v, (JsonSerializerOptions)null))
                .IsRequired();

        }
    }
}
