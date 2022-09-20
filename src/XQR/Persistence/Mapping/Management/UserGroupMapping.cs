namespace Azox.XQR.Persistence.Mapping.Management
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Management;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserGroupMapping :
        EntityMappingBase<UserGroup>
    {
        public override void Configure(EntityTypeBuilder<UserGroup> builder, int lastColumnOrder)
        {
            builder.Property(x => x.IsAdmin)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.HasOne(x => x.Merchant)
                .WithMany(x => x.UserGroups)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
