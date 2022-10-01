namespace Azox.Business.Core.Extensions
{
    using Azox.Business.Core.Domain;
    using Azox.Business.Core.Dto;

    public static class EntityExtensions
    {
        public static TDto ToDto<TEntity, TDto>(this TEntity entity)
            where TEntity : class, IEntity
            where TDto : IDtoFor<TEntity>
        {
            TDto dto = Activator.CreateInstance<TDto>();
            dto.Init(entity);

            return dto;
        }

        public static IEnumerable<TDto> ToDto<TEntity, TDto>(this IEnumerable<TEntity> source)
            where TEntity : class, IEntity
            where TDto : IDtoFor<TEntity>
        {
            foreach (TEntity entity in source)
            {
                yield return ToDto<TEntity, TDto>(entity);
            }
        }
    }
}
