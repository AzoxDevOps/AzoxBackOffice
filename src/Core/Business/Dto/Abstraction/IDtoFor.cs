namespace Azox.Business.Core.Dto
{
    using Azox.Business.Core.Domain;

    /// <summary>
    /// 
    /// </summary>
    public interface IDtoFor<TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        void Init(TEntity entity);
    }
}
