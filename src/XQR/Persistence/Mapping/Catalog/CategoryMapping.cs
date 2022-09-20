namespace Azox.XQR.Persistence.Mapping.Catalog
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Catalog;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CategoryMapping :
        EntityMappingBase<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.Parent)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.IsVisible)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.Property(x => x.DisplayOrder)
                .HasColumnOrder(lastColumnOrder++)
                .IsRequired();

            builder.HasOne(x => x.Picture)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
