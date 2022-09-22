namespace Azox.XQR.Business
{
    using Azox.Business.Core.Service;
    using Azox.XQR.Business.Domain.Management;

    /// <summary>
    /// 
    /// </summary>
    public interface IUserGroupService :
        IEntityService<UserGroup>
    {
        /// <summary>
        /// 
        /// </summary>
        void Insert(UserGroup userGroup);

        /// <summary>
        /// 
        /// </summary>
        Task InsertAsync(UserGroup userGroup);
    }
}
