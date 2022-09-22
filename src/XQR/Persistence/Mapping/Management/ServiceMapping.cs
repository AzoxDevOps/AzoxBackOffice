namespace Azox.XQR.Persistence.Mapping.Management
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Common;
    using Azox.XQR.Business.Domain.Management;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Text.Json;

    public class ServiceMapping :
        EntityMappingBase<Service>
    {
        public override void Configure(EntityTypeBuilder<Service> builder, int lastColumnOrder)
        {
            builder.Property(x => x.ServiceType)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.HasOne(x => x.Merchant)
                .WithMany(x => x.Services)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(x => x.Contacts)
                .HasColumnOrder(lastColumnOrder++)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<Contact>>(v, (JsonSerializerOptions)null),
                    new ValueComparer<ICollection<Contact>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => (ICollection<Contact>)c.ToList()));

            builder.Property(x => x.WorkingHours)
               .HasColumnOrder(lastColumnOrder++)
               .HasConversion(
                   v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                   v => JsonSerializer.Deserialize<List<ServiceWorkingHour>>(v, (JsonSerializerOptions)null),
                   new ValueComparer<ICollection<ServiceWorkingHour>>(
                       (c1, c2) => c1.SequenceEqual(c2),
                       c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                       c => (ICollection<ServiceWorkingHour>)c.ToList()));
        }
    }
}
