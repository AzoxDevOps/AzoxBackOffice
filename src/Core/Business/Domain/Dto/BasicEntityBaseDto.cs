namespace Azox.Business.Core.Domain.Dto
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 
    /// </summary>
    public abstract class BasicEntityBaseDto<TEntity> :
        TrackableEntityBaseDto<TEntity, int>
        where TEntity : BasicEntityBase
    {
        #region Ctor

        protected BasicEntityBaseDto() :
            base()
        {
        }

        protected BasicEntityBaseDto(TEntity entity) :
            base(entity)
        {
            Name = entity.Name;
            Description = entity.Description;
        }

        #endregion Ctor

        #region Properties

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        #endregion Properties
    }
}
