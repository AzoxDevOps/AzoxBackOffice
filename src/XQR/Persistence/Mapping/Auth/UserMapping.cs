namespace Azox.XQR.Persistence.Mapping
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserMapping :
        EntityMappingBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.UserGroup)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnOrder(lastColumnOrder++)
                .HasMaxLength(1024)
                .IsRequired(false);

            builder.Property(x => x.LastName)
                .HasColumnOrder(lastColumnOrder++)
                .HasMaxLength(1024)
                .IsRequired(false);

            builder.Ignore(x => x.FullName);

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

            builder.Property(x => x.PasswordChangeOnFirstLogin)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.Property(x => x.LastLoginTime)
                .HasColumnOrder(lastColumnOrder++);
        }
    }
}
