namespace Azox.Business.Core.Dto
{
    using Azox.Business.Core.Domain;

    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 
    /// </summary>
    public abstract class BasicDtoBase<TEntity> :
        TrackableDtoBase<TEntity, int>
        where TEntity : BasicEntityBase
    {
        #region Methods

        public override void Init(TEntity entity)
        {
            base.Init(entity);

            Name = entity.Name;
            Description = entity.Description;
        }

        #endregion Methods

        #region Properties

        public string Name { get; set; }

        public string? Description { get; set; }

        #endregion Properties
    }
}
