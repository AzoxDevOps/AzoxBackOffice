namespace Azox.XQR.Persistence.Configs
{
    using Azox.Core.Configs;

    internal class DbConfig :
        IConfig
    {
        #region Properties

        public DbProvider Provider { get; set; }

        public string ConnectionString { get; set; }

        public string ConfigName => nameof(DbConfig);

        #endregion Properties
    }
}
