namespace Azox.Toolkit.Blazor
{
    /// <summary>
    /// 
    /// </summary>
    public interface IToastService
    {
        void Show(ToastMessage message);

        void ShowSuccess(string message);

        void ShowError(string message);

        void ShowInfo(string message);

        void ShowWarning(string message);
    }
}