namespace Azox.XQR.Business.Domain.Management
{
    using Azox.Business.Core.Domain;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(MenuItemRight), Schema = EntitySchemes.Management)]
    public class MenuItemRight :
        TrackableEntityBase<int>
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual UserGroup UserGroup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual MenuItem MenuItem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsVisible { get; set; }

        #endregion Properties
    }
}
