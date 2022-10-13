namespace Azox.Persistence.Core
{
    using Azox.Business.Core.Domain;
    using Azox.Core.Reflection;
    using Azox.Persistence.Core.Mapping;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using System;

    public abstract class DbContextBase<TDbContext> :
        DbContext, IDbContext
        where TDbContext : DbContext, IDbContext
    {
        #region Ctor

        public DbContextBase(
            IServiceProvider serviceProvider,
            DbContextOptions<TDbContext> options) :
            base(options)
        {
            
            ServiceProvider = serviceProvider;
        }

        #endregion Ctor

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ITypeFinder typeFinder = ServiceProvider.GetRequiredService<ITypeFinder>();
            List<string> assemblyNames = new();
            List<string> entityMappingTypes = new();

            foreach (Type entityMappingType in typeFinder.FindClassesOf<IEntityMapping>())
            {
                if (!assemblyNames.Contains(entityMappingType.Assembly.FullName))
                {
                    modelBuilder.ApplyConfigurationsFromAssembly(entityMappingType.Assembly);
                    assemblyNames.Add(entityMappingType.Assembly.FullName);
                }

                entityMappingTypes.Add(entityMappingType?.BaseType?.GetGenericArguments()[0].FullName);
            }

            foreach (Type entityType in typeFinder.FindClassesOf<IEntity>())
            {
                if (!entityMappingTypes.Contains(entityType.FullName))
                {
                    modelBuilder.Entity(entityType);
                }
            }
        }

        #endregion Methods

        #region Properties

        protected IServiceProvider ServiceProvider { get; }

        #endregion Properties
    }
}
