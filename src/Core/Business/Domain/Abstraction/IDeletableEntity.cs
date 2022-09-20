namespace Azox.Business.Core.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDeletableEntity
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsDeleted { get; }

        /// <summary>
        /// 
        /// </summary>
        //bool IsPermanentlyDeleted { get; }

        /// <summary>
        /// 
        /// </summary>
        DateTime? DeletionTime { get; }
    }
}