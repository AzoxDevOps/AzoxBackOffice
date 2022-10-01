namespace Azox.XQR.Presentation.Areas.Admin.Services
{
    using Azox.XQR.Presentation.Areas.Admin.Models;

    internal class MerchantModelFactory :
        IMerchantModelFactory
    {
        #region Fields

        private readonly IMerchantService _merchantService;

        #endregion Fields

        #region Ctor

        public MerchantModelFactory(IMerchantService merchantService)
        {
            _merchantService = merchantService;
        }

        #endregion Ctor

        #region Methods

        public virtual async Task<IEnumerable<MerchantModel>> PrepareSummaryModelAsync()
        {
            IEnumerable<Merchant> merchants = await _merchantService.FilterAsync(x => !x.IsDeleted);

            return merchants.Select(merchant => new MerchantModel(merchant));
        }

        public virtual async Task<MerchantModel> PrepareDetailModelAsync(int id)
        {
            MerchantModel model = new();

            if (id > 0)
            {
                Merchant merchant = await _merchantService.GetByIdAsync(id);
                model = new MerchantModel(merchant);
            }

            return model;
        }

        #endregion Methods
    }
}
