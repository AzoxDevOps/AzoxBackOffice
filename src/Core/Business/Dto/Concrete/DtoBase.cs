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
        #region Ctor

        protected DtoBase()
        {
            IsNew = true;
        }

        #endregion Ctor

        #region Methods

        public virtual void Init(TEntity entity)
        {
            IsNew = false;
            Id = entity.Id;
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public TId Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsNew { get; private set; }

        #endregion Properties
    }
}