namespace Azox.Business.Core.Dto
{
    using Azox.Business.Core.Domain;

    /// <summary>
    /// 
    /// </summary>
    public abstract class DtoBase<TEntity, TId> :
        IDtoFor<TEntity>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        #region Methods

        public virtual void Init(TEntity entity)
        {
            Id = entity.Id;
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public TId Id { get; protected internal set; }

        #endregion Properties
    }
}