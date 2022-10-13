namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Microsoft.AspNetCore.Components;

    public partial class Detail
    {
        #region Fields

        private bool _showToolbar;

        #endregion Fields

        #region Parameters

        [Parameter]
        public EventCallback OnSaveClick { get; set; }

        [Parameter]
        public RenderFragment DetailView { get; set; }

        [Parameter]
        public string PageTitle { get; set; }

        [Parameter]
        public bool ShowHeader { get; set; }

        [Parameter]
        public bool ShowToolbar
        {
            get => _showToolbar;
            set
            {
                _showToolbar = value;
                if (_showToolbar)
                {
                    ShowHeader = true;
                }
            }
        }

        #endregion Parameters

        #region Methods

        private async Task OnSave()
        {
            await OnSaveClick.InvokeAsync();
        }

        #endregion Methods
    }
}
