namespace Azox.XQR.Persistence.Mapping.Media
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business.Domain.Media;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ProductPictureMapping :
        EntityMappingBase<ProductPicture>
    {
        public override void Configure(EntityTypeBuilder<ProductPicture> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.Product)
                .WithMany(x => x.Pictures)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .IsRequired();

            builder.HasOne(x => x.Picture)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction)
                .IsRequired();
        }
    }
}
