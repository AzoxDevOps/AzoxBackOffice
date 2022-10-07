namespace Azox.Business.Core.Domain
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    [Table(nameof(InstallationStep))]
    public class InstallationStep :
        EntityBase<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string StepName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string? Error { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastExecutionTime { get; set; }
    }
}
