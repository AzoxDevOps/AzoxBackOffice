namespace Azox.XQR.Persistence.Mapping.Region
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Region;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class AddressMapping:
        EntityMappingBase<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.City)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.District)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(x => x.AddressLine)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.Property(x=>x.Latitude)
                .HasColumnOrder(lastColumnOrder++);

            builder.Property(x => x.Longitude)
                .HasColumnOrder(lastColumnOrder++);
        }
    }
}
