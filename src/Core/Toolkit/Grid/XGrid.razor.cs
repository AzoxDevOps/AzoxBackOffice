namespace Azox.Toolkit.Blazor
{
    using Microsoft.AspNetCore.Components;

    public partial class XGrid<TModel> :
        XComponentBase
    {
        #region Parameters

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public RenderFragment Columns { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public IEnumerable<TModel> DataSource { get; set; }

        #endregion Parameters
    }
}
