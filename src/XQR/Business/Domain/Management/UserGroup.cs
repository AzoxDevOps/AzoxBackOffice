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
        public virtual Merchant? Merchant { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsAdmin { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<User> Users { get; set; }

        #endregion Properties
    }
}
