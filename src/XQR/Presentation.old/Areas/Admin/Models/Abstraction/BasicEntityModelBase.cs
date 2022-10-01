namespace Azox.XQR.Presentation.Areas.Admin.Models
{
    using Azox.Business.Core.Domain;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 
    /// </summary>
    public abstract class BasicEntityModelBase<TEntity> :
        TrackableEntityModelBase<TEntity, int>
        where TEntity : BasicEntityBase
    {
        #region Ctor

        public BasicEntityModelBase()
        {

        }

        public BasicEntityModelBase(TEntity entity) :
            base(entity)
        {
            Name = entity.Name;
            Description = entity.Description;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Description { get; set; }

        #endregion Properties
    }
}
