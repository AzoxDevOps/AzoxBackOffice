namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;

    using System.Threading.Tasks;

    public partial class GenericDetail<TModel>
    {
        #region Parameters

        [Parameter]
        public TModel Model { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment MobileTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment BreadCrumb { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment Template { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment ToolbarTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment MobileToolbarTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EventCallback OnClose { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EventCallback OnDelete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnSave { get; set; }

        #endregion Parameters

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            EditContext = new(Model);
        }

        private async Task OnSaveAndCloseAsync()
        {
            await OnSave.InvokeAsync(true);
            await OnClose.InvokeAsync();
        }

        private async Task OnCloseAsync()
        {
            await OnClose.InvokeAsync();
        }

        private async Task OnDeleteAsync()
        {
            await OnDelete.InvokeAsync();
        }

        private async Task OnValidSubmit()
        {
            await OnSave.InvokeAsync(false);
        }

        #endregion Methods

        #region Properties

        private EditContext EditContext { get; set; }

        #endregion Properties
    }
}
