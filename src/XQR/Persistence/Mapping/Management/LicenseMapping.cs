namespace Azox.XQR.Persistence.Mapping.Management
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Management;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Text.Json;

    internal class LicenseMapping :
        EntityMappingBase<License>
    {
        public override void Configure(EntityTypeBuilder<License> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.Merchant)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(x => x.LicenseKey)
                .HasColumnOrder(lastColumnOrder++)
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(x => x.LicenseData)
                .HasColumnOrder(lastColumnOrder++)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<LicenseData>(v, (JsonSerializerOptions)null))
                .IsRequired();
        }
    }
}
