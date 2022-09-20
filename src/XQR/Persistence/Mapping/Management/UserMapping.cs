namespace Azox.XQR.Persistence.Mapping.Management
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Management;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserMapping :
        EntityMappingBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.UserGroup)
                .WithMany(x => x.Users)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(x => x.Username)
                .HasColumnOrder(lastColumnOrder++)
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(x => x.PasswordSalt)
                .HasColumnOrder(lastColumnOrder++)
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasColumnOrder(lastColumnOrder++)
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.Property(x => x.IsLocked)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();
        }
    }
}
