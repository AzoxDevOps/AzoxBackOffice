namespace Azox.XQR.Business
{
    using Azox.Business.Core.Service;

    /// <summary>
    /// 
    /// </summary>
    public interface IProductService :
        IEntityService<Product>
    {
        /// <summary>
        /// 
        /// </summary>
        Product Create(int categoryId, string name, string description, Price price);
    }
}
