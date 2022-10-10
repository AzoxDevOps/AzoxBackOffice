namespace Azox.XQR.Business.Dto
{
    using Azox.Business.Core.Dto;

    public class ProductDto :
        DeletableBasicDtoBase<Product>
    {
        #region Ctor

        public ProductDto()
        {
            Category = new();
            Price = new();
            OldPrice = new();
        }

        #endregion Ctor

        #region Methods

        public override void Init(Product entity)
        {
            base.Init(entity);

            IsActive = entity.IsActive;
            DisplayOrder = entity.DisplayOrder;

            if (entity.Category != null)
            {
                Category.Init(entity.Category);
            }

            if (entity.Price != null)
            {
                Price = new Price(entity.Price.Amount, entity.Price.Currency);
            }

            if (entity.OldPrice != null)
            {
                Price = new Price(entity.OldPrice.Amount, entity.OldPrice.Currency);
            }
        }

        #endregion Methods

        #region Properties

        public CategoryDto Category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Price Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Price OldPrice { get; set; }

        #endregion Properties
    }
}
