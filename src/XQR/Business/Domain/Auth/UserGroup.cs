namespace Azox.XQR.Business
{
    using Azox.Business.Core.Domain;

    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(UserGroup), Schema = EntitySchemes.Auth)]
    public class UserGroup :
        DeletableBasicEntityBase
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual UserGroupType UserGroupType { get; set; }

        #endregion Properties
    }
}
