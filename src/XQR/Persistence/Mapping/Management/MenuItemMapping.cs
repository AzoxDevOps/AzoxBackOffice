namespace Azox.XQR.Persistence.Mapping.Management
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Management;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class MenuItemMapping :
        EntityMappingBase<MenuItem>
    {
        public override void Configure(EntityTypeBuilder<MenuItem> builder, int lastColumnOrder)
        {
            builder.Property(x => x.Url)
                .HasColumnOrder(lastColumnOrder++)
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(x => x.Icon)
                .HasColumnOrder(lastColumnOrder++)
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(x => x.DisplayOrder)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.HasOne(x => x.Parent)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
