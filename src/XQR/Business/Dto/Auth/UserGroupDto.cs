namespace Azox.XQR.Business.Dto
{
    using Azox.Business.Core.Dto;

    /// <summary>
    /// 
    /// </summary>
    public class UserGroupDto :
        DeletableBasicDtoBase<UserGroup>
    {
        #region Ctor

        #endregion Ctor

        #region Methods

        public override void Init(UserGroup entity)
        {
            base.Init(entity);

            UserGroupType = entity.UserGroupType;
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public UserGroupType UserGroupType { get; set; }

        #endregion Properties
    }
}
