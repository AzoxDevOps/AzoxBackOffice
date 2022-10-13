namespace Azox.XQR.Business
{
    using Azox.Business.Core.Service;

    /// <summary>
    /// 
    /// </summary>
    public interface ICategoryService :
        IEntityService<Category>
    {
        /// <summary>
        /// 
        /// </summary>
        Category Create(int merchantServeId, string name, string description);
    }
}
