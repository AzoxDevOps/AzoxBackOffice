namespace Azox.XQR.Persistence.Mapping
{
    using Azox.Persistence.Core.Mapping;
    using Azox.XQR.Business;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class MerchantServeUserMapping :
        EntityMappingBase<MerchantServeUser>
    {
        public override void Configure(EntityTypeBuilder<MerchantServeUser> builder, int lastColumnOrder)
        {
            builder.HasOne(x => x.Service)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
