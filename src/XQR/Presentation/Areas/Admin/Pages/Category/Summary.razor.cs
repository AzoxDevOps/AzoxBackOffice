namespace Azox.XQR.Presentation.Areas.Admin.Pages.Category
{
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;
    using Microsoft.AspNetCore.Components;
    using System.Threading.Tasks;

    public partial class Summary
    {
        #region Injects

        [Inject]
        private ICategoryService CategoryService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        #endregion Injects

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            DataSource = await CategoryService.GetAllAsync<CategoryDto>();
        }

        private async Task Search()
        {
            await Task.CompletedTask;
        }

        #endregion Methods

        #region Properties

        private IEnumerable<CategoryDto> DataSource { get; set; }

        #endregion Properties
    }
}
