namespace Azox.XQR.Persistence.Mapping
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CategoryMapping :
        EntityMappingBase<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.Service)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.Parent)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.IsVisible)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.Property(x => x.DisplayOrder)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();
        }
    }
}
