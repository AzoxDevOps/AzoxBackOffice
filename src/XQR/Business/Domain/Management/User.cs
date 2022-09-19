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
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual UserGroup UserGroup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string PasswordSalt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string PasswordHash { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsActive { get; set; }

        #endregion Properties
    }
}
