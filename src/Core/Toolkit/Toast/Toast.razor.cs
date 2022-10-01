namespace Azox.Toolkit.Blazor
{
    using Microsoft.AspNetCore.Components;

    public partial class Toast :
        ComponentBase
    {
        #region Injects

        [Inject]
        private IToastService ToastService { get; set; }

        #endregion Injects

        #region Methods

        public void Close()
        {
            ((IInternalToastService)ToastService).Messages.Remove(Message);
            Task.Delay(0).ContinueWith(r => { Visible = false; });
        }

        protected override void OnInitialized()
        {
            Task.Delay(Message.Duration ?? 3000).ContinueWith(r => InvokeAsync(Close));
        }

        #endregion Methods

        #region Parameters

        [Parameter]
        public ToastMessage Message { get; set; }

        #endregion Parameters

        #region Properties

        public bool Visible { get; set; } = true;

        #endregion Properties
    }
}
