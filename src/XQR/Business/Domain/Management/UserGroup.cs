namespace Azox.XQR.Business.Domain.Management
{
    using Azox.Business.Core.Domain;

    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(UserGroup), Schema = EntitySchemes.Management)]
    public class UserGroup :
        DeletableBasicEntityBase
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual Service? Service { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual UserGroupType UserGroupType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<User> Users { get; set; }

        #endregion Properties
    }
}
