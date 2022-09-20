namespace Azox.XQR.Persistence.Mapping.Management
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Management;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class MenuItemRightMapping :
        EntityMappingBase<MenuItemRight>
    {
        public override void Configure(EntityTypeBuilder<MenuItemRight> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.UserGroup)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.MenuItem)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(x => x.IsVisible)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();
        }
    }
}
