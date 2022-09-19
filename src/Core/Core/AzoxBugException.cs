namespace Azox.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class AzoxBugException :
        AzoxException
    {
        #region Ctor

        public AzoxBugException() :
            base()
        {

        }

        public AzoxBugException(string message) :
            base(message)
        {

        }

        public AzoxBugException(int code) :
            base($"[BUG:{code}]")
        {

        }

        #endregion Ctor
    }
}
