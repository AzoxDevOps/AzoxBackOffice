namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category
{
    using Azox.Toolkit.Blazor;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.Logging;

    public partial class CategoryDetail
    {
        #region Injects

        [Inject]
        private ILogger<CategoryDetail> Logger { get; set; }

        [Inject]
        private ICategoryService CategoryService { get; set; }

        [Inject]
        private IMerchantServeService MerchantServeService { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        [Inject]
        private NavigationManager Navigator { get; set; }

        #endregion Injects

        #region Parameters

        [CascadingParameter]
        public CategoryDto Model { get; set; }

        #endregion Parameters

        #region Methods

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (!firstRender)
            {
                if (MerchantServices == null)
                {
                    if (AuthorizedServiceIds.Any())
                    {
                        MerchantServices = MerchantServeService
                            .Filter(x => AuthorizedServiceIds.Contains(x.Id) && !x.IsDeleted)
                            .Select(x => new SelectListItem
                            {
                                Text = x.Name,
                                Value = x.Id.ToString()
                            });
                    }
                    else
                    {
                        MerchantServices = MerchantServeService
                            .Filter(x => !x.IsDeleted)
                            .Select(x => new SelectListItem
                            {
                                Text = x.Name,
                                Value = x.Id.ToString()
                            });
                    }
                    StateHasChanged();
                }
            }
        }

        private void OnSave()
        {
            try
            {
                if (Model.IsNew)
                {
                    Category category = CategoryService
                        .Create(Model.Service.Id, Model.Name, Model.Description);

                    Navigator.NavigateTo($"/admin/category/{category.Id}");
                }
                else
                {

                }

                ToastService.ShowSuccess(Resources.SaveSuccessful);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }
        }

        private async Task OnDelete()
        {
            await Task.CompletedTask;
        }

        private void OnClose()
        {
            Navigator.NavigateTo("/admin/category/list");
        }

        #endregion Methods

        #region Properties

        private IEnumerable<SelectListItem> MerchantServices { get; set; }

        #endregion Properties
    }
}
