namespace Azox.XQR.Business.Domain.Catalog
{
    using Azox.Business.Core.Domain.Dto;

    /// <summary>
    /// 
    /// </summary>
    public class CategoryDto :
        BasicEntityBaseDto<Category>
    {
        #region Ctor

        public CategoryDto() : base()
        {

        }

        public CategoryDto(Category category) :
            base(category)
        {
            DisplayOrder = category.DisplayOrder;
            IsVisible = category.IsVisible;
        }

        #endregion Ctor

        #region Properties

        public int DisplayOrder { get; set; }

        public bool IsVisible { get; set; }

        #endregion Properties
    }
}
