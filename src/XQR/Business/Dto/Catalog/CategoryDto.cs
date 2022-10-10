namespace Azox.XQR.Business.Dto
{
    using Azox.Business.Core.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoryDto:
        DeletableBasicDtoBase<Category>
    {
        #region Methods

        public override void Init(Category entity)
        {
            base.Init(entity);

            IsVisible = entity.IsActive;
            DisplayOrder = entity.DisplayOrder;

            if (entity.Service!= null)
            {
                Service.Init(entity.Service);
            }

            if (entity.Parent != null)
            {
                Parent = new();
                Parent.Init(entity.Parent);
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public MerchantServeDto Service { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CategoryDto Parent { get; set; }

        #endregion Properties
    }
}
