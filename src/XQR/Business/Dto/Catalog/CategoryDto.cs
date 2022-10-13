namespace Azox.XQR.Business.Dto
{
    using Azox.Business.Core.Dto;

    using System.Collections.Generic;

    public class CategoryDto :
        DeletableBasicDtoBase<Category>
    {
        #region Fields

        private CategoryDto _parent;

        #endregion Fields

        #region Ctor

        public CategoryDto()
        {
            Service = new();
        }

        #endregion Ctor

        #region Methods

        private void SetName(Category entity)
        {
            Category _entity = entity;
            List<string> names = new();

            while (_entity.Parent != null)
            {
                names.Add(_entity.Name);
                _entity = _entity.Parent;
            }

            names.Reverse();
            FullName = string.Join(" >> ", names);
        }

        public override void Init(Category entity)
        {
            base.Init(entity);

            IsActive = entity.IsActive;
            DisplayOrder = entity.DisplayOrder;
            SetName(entity);

            if (entity.Service != null)
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
        public string FullName { get; set; }

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
        public CategoryDto Parent { get; set; }

        #endregion Properties
    }
}
