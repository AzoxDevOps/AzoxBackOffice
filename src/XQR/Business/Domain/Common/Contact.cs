namespace Azox.XQR.Business.Domain.Common
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public class Contact
    {
        #region Ctor

        public Contact()
        {
        }

        [JsonConstructor]
        public Contact(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        #endregion Properties
    }
}