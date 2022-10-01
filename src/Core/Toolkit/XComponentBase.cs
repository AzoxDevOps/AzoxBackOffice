namespace Azox.Toolkit.Blazor
{
    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// 
    /// </summary>
    public abstract class XComponentBase :
        ComponentBase,
        IDisposable
    {
        #region Parameters

        /// <summary>
        /// 
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object> Attributes { get; set; }

        #endregion Parameters

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public ElementReference Element { get; set; }

        #endregion Properties

        #region IDisposable Members

        public virtual void Dispose()
        {
            
        }

        #endregion IDisposable Members
    }
}
