namespace Azox.XQR.Persistence.Mapping.Management
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Common;
    using Azox.XQR.Business.Domain.Management;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Text.Json;

    internal class ExternalServiceMapping :
        EntityMappingBase<ExternalService>
    {
        public override void Configure(EntityTypeBuilder<ExternalService> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.Merchant)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(x => x.Contact)
               .HasColumnOrder(lastColumnOrder++)
               .HasConversion(
                   v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                   v => JsonSerializer.Deserialize<Contact>(v, (JsonSerializerOptions)null))
               .IsRequired();
        }
    }
}
