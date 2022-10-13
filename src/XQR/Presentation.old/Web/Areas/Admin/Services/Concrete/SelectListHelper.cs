namespace Azox.XQR.Presentation.Web.Areas.Admin.Services
{
    using Azox.Core.Extensions;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Dto;

    using Microsoft.AspNetCore.Mvc.Rendering;

    using System.Linq.Expressions;

    public class SelectListHelper :
        ISelectListHelper
    {
        #region Fields
        private readonly IAuthService _authService;
        private readonly ICategoryService _categoryService;

        #endregion Fields

        #region Ctor

        public SelectListHelper(
            IAuthService authService,
            ICategoryService categoryService)
        {
            _authService = authService;
            _categoryService = categoryService;
        }

        #endregion Ctor

        #region Utils

        private IEnumerable<CategoryDto> GetCategories(int? parentId)
        {
            UserGroupType userGroupType = _authService.GetUserGroupType().Result;
            Expression<Func<Category, bool>> predicate = x => !x.IsDeleted;
            List<CategoryDto> categories = new();

            if (parentId != null)
            {
                predicate = predicate.And(x => x.Parent != null && x.Parent.Id == parentId);
            }

            if (userGroupType == UserGroupType.MerchantAdmin)
            {
                int merchantId = _authService.GetMerchantId().Result;
                predicate = predicate.And(x => x.Service.Merchant.Id == merchantId);
            }
            else if (userGroupType == UserGroupType.ServiceAdmin)
            {
                int serviceId = _authService.GetServiceId().Result;
                predicate = predicate.And(x => x.Service.Id == serviceId);
            }

            foreach (var item in _categoryService.Filter<CategoryDto>(predicate, x => x.DisplayOrder))
            {
                categories.Add(item);
                categories.AddRange(GetCategories(item.Id));
            }

            return categories;
        }

        #endregion Utils

        #region Methods

        public virtual IEnumerable<SelectListItem> GetCategorySelectList()
        {
            return GetCategories(null)
                .Select(x => new SelectListItem
                {
                    Text = x.FullName,
                    Value = x.Id.ToString()
                });
        }

        #endregion Methods
    }
}
