namespace Azox.Toolkit.Blazor
{
    using System.Collections.ObjectModel;

    internal class ToastService :
        IToastService,
        IInternalToastService
    {
        #region Fields

        private readonly ObservableCollection<ToastMessage> _messages;

        #endregion Fields

        #region Ctor

        public ToastService()
        {
            _messages = new();
        }

        #endregion Ctor

        #region Methods

        public void Show(ToastMessage message)
        {
            ToastMessage newMessage = new ToastMessage
            {
                Duration = message.Duration,
                Message = message.Message,
                Type = message.Type,
            };

            if (!_messages.Contains(newMessage))
            {
                _messages.Add(newMessage);
            }
        }

        public void ShowSuccess(string message)
        {
            Show(new ToastMessage
            {
                Message = message,
                Type = ToastType.Success,
            });
        }

        public void ShowError(string message)
        {
            Show(new ToastMessage
            {
                Message = message,
                Type = ToastType.Error,
            });
        }

        public void ShowInfo(string message)
        {
            Show(new ToastMessage
            {
                Message = message,
                Type = ToastType.Info,
            });
        }

        public void ShowWarning(string message)
        {
            Show(new ToastMessage
            {
                Message = message,
                Type = ToastType.Warning,
            });
        }

        #endregion Methods

        #region Properties

        public ObservableCollection<ToastMessage> Messages => _messages;

        #endregion Properties
    }
}
