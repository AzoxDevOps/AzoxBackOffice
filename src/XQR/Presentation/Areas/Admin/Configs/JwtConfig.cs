namespace Azox.XQR.Presentation.Areas.Admin.Configs
{
    using Azox.Core.Configs;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    internal class JwtConfig :
        IConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] SecretKeyBytes => Encoding.ASCII.GetBytes(SecretKey);

        /// <summary>
        /// 
        /// </summary>
        public string ConfigName => nameof(JwtConfig);
    }
}
