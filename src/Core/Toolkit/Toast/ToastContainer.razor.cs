namespace Azox.Toolkit.Blazor
{
    using Microsoft.AspNetCore.Components;
    using System;
    using System.Collections.Specialized;

    public partial class ToastContainer :
        ComponentBase,
        IDisposable
    {
        #region Injects

        [Inject]
        private IToastService ToastService { get; set; }

        #endregion Injects

        #region Utils

        private RenderFragment DrawToast(int index, ToastMessage message)
        {
            return new RenderFragment(builder =>
            {
                int i = 0;
                builder.OpenComponent(i, typeof(Toast));
                builder.AddAttribute(i++, "Message", message);
                builder.CloseComponent();
            });
        }

        private void Update(object? sender, NotifyCollectionChangedEventArgs args)
        {
            InvokeAsync(StateHasChanged);
        }

        #endregion Utils

        #region Methods

        protected override void OnInitialized()
        {
            ((IInternalToastService)ToastService).Messages.CollectionChanged += Update;
        }

        #endregion Methods

        #region IDisposable Members

        public void Dispose()
        {
            ((IInternalToastService)ToastService).Messages.CollectionChanged -= Update;
        }

        #endregion IDisposable Members

        #region Parameters

        /// <summary>
        /// 
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object> Attributes { get; set; }

        #endregion Parameter
    }
}
