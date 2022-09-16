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
        #region Fields

        private readonly IList<User> _users;

        #endregion Fields

        #region Ctor

        protected UserGroup() { }

        protected internal UserGroup(
            string name,
            string description) :
            base(name, description)
        {
            _users = new List<User>();
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsAdmin { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<User> Users => _users;

        #endregion Properties
    }
}
