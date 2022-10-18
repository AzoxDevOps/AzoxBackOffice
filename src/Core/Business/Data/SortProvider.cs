namespace Azox.Business.Core
{
    using Azox.Business.Core.Data;
    using Azox.Business.Core.Domain;

    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    public class SortProvider<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Expression<Func<TEntity, object>> Predicate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SortOrder SortOrder { get; set; } = SortOrder.Ascending;
    }
}
