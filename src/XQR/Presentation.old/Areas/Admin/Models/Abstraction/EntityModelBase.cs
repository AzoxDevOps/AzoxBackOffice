namespace Azox.XQR.Presentation.Areas.Admin.Models
{
    using Azox.Business.Core.Domain;

    /// <summary>
    /// 
    /// </summary>
    public abstract class EntityModelBase<TEntity, TId>
        where TId : struct
        where TEntity : EntityBase<TId>
    {
        #region Ctor

        public EntityModelBase()
        {

        }

        public EntityModelBase(TEntity entity)
        {
            Id = entity.Id;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public TId Id { get; set; }

        #endregion Properties
    }
}