namespace Azox.Persistence.Core.Configs
{
    using Azox.Core.Configs;

    public class DbConfig :
        IConfig
    {
        #region Properties

        public DbProvider Provider { get; set; }

        public string ConnectionString { get; set; }

        public string ConfigName => nameof(DbConfig);

        #endregion Properties
    }
}
