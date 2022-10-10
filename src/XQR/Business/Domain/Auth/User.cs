namespace Azox.XQR.Business
{
    using Azox.Business.Core.Domain;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(User), Schema = EntitySchemes.Auth)]
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
        public virtual string? FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string? LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string FullName => $"{FirstName} {LastName}";

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

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsLocked { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool PasswordChangeOnFirstLogin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastLoginTime { get; set; }

        #endregion Properties
    }
}
