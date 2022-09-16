namespace Azox.XQR.Business.Domain.Management
{
    using Azox.Business.Core.Domain;

    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(User), Schema = EntitySchemes.Management)]
    public class User :
        DeletableTrackableEntityBase<int>
    {
        #region Ctor

        protected User() { }

        protected internal User(
            UserGroup userGroup,
            string username,
            string passwordSalt,
            string passwordHash)
        {
            Username = username;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual UserGroup UserGroup { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Username { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string PasswordSalt { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string PasswordHash { get; private set; }

        #endregion Properties
    }
}
