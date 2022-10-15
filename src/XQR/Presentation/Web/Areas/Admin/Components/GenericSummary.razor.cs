namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Microsoft.AspNetCore.Components;

    public partial class GenericSummary
    {
        #region Fields

        private bool _searchIsBusy;

        #endregion Fields

        #region Parameters

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment MobileTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EventCallback OnSearch { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EventCallback OnCreate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public string PageTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment SearchTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment Template { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public bool ShowToolbar { get; set; }

        #endregion Parameters

        #region Methods

        private async Task OnCreateAsync()
        {
            await OnCreate.InvokeAsync();
        }

        private async Task OnSearchAsync()
        {
            _searchIsBusy = true;
            await OnSearch.InvokeAsync();
            _searchIsBusy = false;
        }

        #endregion Methods
    }
}
