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
        }

        private void OnSave(bool saveAndClose)
        {
            try
            {
                if (Model.IsNew)
                {
                    Category category = CategoryService
                        .Create(Model.Service.Id, Model.Name, Model.Description);

                    Model.Id = category.Id;
                }
                else
                {
                    Category category = CategoryService.GetById(Model.Id);

                    category.Name = Model.Name;
                    category.Description = Model.Description;
                    category.DisplayOrder = Model.DisplayOrder;
                    category.IsActive = Model.IsActive;

                    CategoryService.Update(category);
                }

                if (!saveAndClose)
                {
                    Navigator.NavigateTo($"/admin/category/{Model.Id}");
                }

                ToastService.ShowSuccess(XResource.SaveSuccessful);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }
        }

        private async Task OnDelete()
        {
            bool confirm = await JsRuntimeHelper.GetConfirmResult(XResource.DeleteConfirm);
            if (confirm)
            {
                await Task.Run(() => CategoryService.Delete(Model.Id));
                await OnClose();
            }
        }

        private async Task OnClose()
        {
            await Task.Run(() => Navigator.NavigateTo("/admin/category/list"));
        }

        #endregion Methods
    }
}
