namespace Azox.XQR.Persistence
{
    using Azox.Core.Reflection;
    using Azox.Persistence.Core;
    using Azox.Persistence.Core.Mapping;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// 
    /// </summary>
    internal class XQRDbContext :
        DbContext,
        IDbContext
    {
        #region Fields

        private readonly IServiceProvider _serviceProvider;

        #endregion Fields

        #region Ctor

        public XQRDbContext(
            IServiceProvider serviceProvider,
            DbContextOptions<XQRDbContext> options) :
            base(options)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion Ctor

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ITypeFinder typeFinder = _serviceProvider.GetRequiredService<ITypeFinder>();
            List<string> assemblyNames = new();

            foreach (Type entityMappingType in typeFinder.FindClassesOf<IEntityMapping>())
            {
                if (!assemblyNames.Contains(entityMappingType.Assembly.FullName))
                {
                    modelBuilder.ApplyConfigurationsFromAssembly(entityMappingType.Assembly);
                }
            }
        }

        #endregion Methods
    }
}
