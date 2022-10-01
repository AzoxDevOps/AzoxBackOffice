namespace Azox.XQR.Presentation.Areas.Admin.Services
{
    using Azox.XQR.Presentation.Areas.Admin.Models;

    /// <summary>
    /// 
    /// </summary>
    public interface IMerchantModelFactory
    {
        /// <summary>
        /// 
        /// </summary>
        Task<IEnumerable<MerchantModel>> PrepareSummaryModelAsync();

        /// <summary>
        /// 
        /// </summary>
        Task<MerchantModel> PrepareDetailModelAsync(int id);
    }
}
