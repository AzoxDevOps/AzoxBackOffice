namespace Azox.XQR.Business.Dto
{
    using Azox.Business.Core.Dto;

    public class UserDto :
        DeletableTrackableDtoBase<User, int>
    {
        #region Ctor

        public UserDto()
        {
            UserGroup = new();
            TempPassword = Convert.ToBase64String(Guid.NewGuid().ToByteArray())[..8];
        }

        #endregion Ctor

        #region Methods

        public override void Init(User entity)
        {
            base.Init(entity);

            FirstName = entity.FirstName;
            LastName = entity.LastName;
            Username = entity.Username;
            IsActive = entity.IsActive;
            IsLocked = entity.IsLocked;
            LastLoginTime = entity.LastLoginTime;

            if (entity.UserGroup != null)
            {
                UserGroup.Init(entity.UserGroup);
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public UserGroupDto UserGroup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// 
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TempPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        #endregion Properties
    }
}
