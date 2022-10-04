namespace Azox.XQR.Persistence.Mapping
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Text.Json;

    public class MerchantServeMapping :
        EntityMappingBase<MerchantServe>
    {
        public override void Configure(EntityTypeBuilder<MerchantServe> builder, int lastColumnOrder)
        {
            builder.Property(x => x.IsActive)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.Property(x => x.ServiceType)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.HasOne(x => x.Merchant)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(x => x.Contacts)
                .HasColumnOrder(lastColumnOrder++)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<Contact>>(v, (JsonSerializerOptions)null),
                    new ValueComparer<List<Contact>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => (List<Contact>)c.ToList()))
                .IsRequired(false);

            builder.Property(x => x.WorkingHours)
               .HasColumnOrder(lastColumnOrder++)
               .HasConversion(
                   v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                   v => JsonSerializer.Deserialize<List<MerchantServeWorkingHour>>(v, (JsonSerializerOptions)null),
                   new ValueComparer<List<MerchantServeWorkingHour>>(
                       (c1, c2) => c1.SequenceEqual(c2),
                       c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                       c => (List<MerchantServeWorkingHour>)c.ToList()))
               .IsRequired(false);

            builder.Property(x => x.ThemeTypeName)
               .HasColumnOrder(lastColumnOrder++)
               .HasMaxLength(1024);
        }
    }
}
