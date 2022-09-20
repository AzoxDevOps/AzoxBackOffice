namespace Azox.XQR.Business.Domain.Common
{
    /// <summary>
    /// 
    /// </summary>
    public readonly struct Contact
    {
        #region Ctor

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
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; }

        #endregion Properties
    }
}