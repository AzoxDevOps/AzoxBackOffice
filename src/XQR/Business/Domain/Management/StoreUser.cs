namespace Azox.XQR.Business.Domain.Management
{
    using Azox.Business.Core.Domain;

    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(StoreUser), Schema = EntitySchemes.Management)]
    public class StoreUser :
        TrackableEntityBase<int>
    {
        #region Ctor

        protected StoreUser() { }

        protected internal StoreUser(
            Store store,
            User user)
        {
            Store = store;
            User = user;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual Store Store { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual User User { get; private set; }

        #endregion Properties
    }
}
