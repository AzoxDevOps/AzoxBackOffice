namespace Azox.Persistence.Core.Mapping
{
    using Azox.Business.Core.Domain;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public abstract class EntityMappingBase<TEntity> :
        IEntityTypeConfiguration<TEntity>,
        IEntityMapping
        where TEntity : class, IEntity
    {
        #region Methods

        public virtual void Configure(EntityTypeBuilder<TEntity> builder, int lastColumnOrder)
        {

        }

        void IEntityTypeConfiguration<TEntity>.Configure(EntityTypeBuilder<TEntity> builder)
        {
            Type entityType = typeof(TEntity);
            int columnOrder = 1;

            if (typeof(ITrackableEntity).IsAssignableFrom(entityType))
            {
                builder.Property(nameof(ITrackableEntity.CreationTime))
                    .HasColumnOrder(columnOrder++)
                    .IsRequired();

                builder.HasIndex(nameof(ITrackableEntity.CreationTime));
            }

            if (typeof(IBasicEntity).IsAssignableFrom(entityType))
            {
                builder.Property(nameof(IBasicEntity.Name))
                    .HasMaxLength(1024)
                    .HasColumnOrder(columnOrder++)
                    .IsRequired();

                builder.Property(nameof(IBasicEntity.Description))
                    .HasColumnOrder(columnOrder++)
                    .HasMaxLength(4000);

                builder.HasIndex(nameof(IBasicEntity.Name));
            }

            if (typeof(IDeletableEntity).IsAssignableFrom(entityType))
            {
                builder.Property(nameof(IDeletableEntity.IsDeleted))
                    .HasColumnOrder(columnOrder++)
                    .IsRequired();

                builder.Property(nameof(IDeletableEntity.DeletionTime))
                    .HasColumnOrder(columnOrder++);
            }

            Configure(builder, columnOrder);
        }

        #endregion Methods
    }
}
