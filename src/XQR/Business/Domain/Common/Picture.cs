namespace Azox.XQR.Business
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public class Picture
    {
        #region Ctor

        public Picture()
        {

        }

        [JsonConstructor]
        public Picture(string fileName)
        {
            FileName = fileName;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }

        #endregion Properties
    }
}
