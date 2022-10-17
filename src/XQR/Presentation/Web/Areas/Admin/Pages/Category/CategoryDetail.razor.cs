namespace Azox.XQR.Presentation.Web.Areas.Admin.Pages.Category
{
    using Azox.Toolkit.Blazor;
    using Azox.Toolkit.Blazor.Helpers;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Azox.XQR.Presentation.Core.Localization;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;

    public partial class CategoryDetail
    {
        #region Injects

        [Inject]
        private IJsRuntimeHelper JsRuntimeHelper { get; set; }

        [Inject]
        private ICategoryService CategoryService { get; set; }

        [Inject]
        private ILogger<CategoryDetail> Logger { get; set; }

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

        protected override void OnInitialized()
        {
            base.OnInitialized();
            EditContext = new(Model);
        }

        private void OnSave()
        {
            try
            {


                ToastService.ShowSuccess(Resources.SaveSuccessful);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }
        }

        private async Task OnDelete()
        {
            bool confirm = await JsRuntimeHelper.GetConfirmResult(Resources.DeleteConfirm);
            if (confirm)
            {
                CategoryService.Delete(Model.Id);
                OnClose();
            }
        }

        private void OnClose()
        {
            Navigator.NavigateTo("/admin/category/list");
        }

        #endregion Methods

        #region Properties

        private EditContext EditContext { get; set; }

        #endregion Properties
    }
}
