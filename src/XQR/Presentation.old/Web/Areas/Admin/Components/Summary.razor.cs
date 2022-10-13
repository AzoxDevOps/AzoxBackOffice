namespace Azox.XQR.Presentation.Web.Areas.Admin.Components
{
    using Microsoft.AspNetCore.Components;

    public partial class Summary
    {
        #region Fields

        private bool _showToolbar;

        #endregion Fields

        #region Parameters

        [Parameter]
        public EventCallback OnCreateClick { get; set; }

        [Parameter]
        public RenderFragment SummaryView { get; set; }

        [Parameter]
        public RenderFragment MobileView { get; set; }

        [Parameter]
        public string PageTitle { get; set; }

        [Parameter]
        public bool ShowHeader { get; set; }

        [Parameter]
        public bool ShowToolbar {
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

        private async Task OnCreate()
        {
            await OnCreateClick.InvokeAsync();
        }

        #endregion Methods
    }
}
