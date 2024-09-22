using SmallStore.Core.Models;

namespace SmallStore.Core.Abstractions
{
    public interface IProductsService
    {
        Task<Guid> CreateProduct(Product product);
        Task<Guid> UpdateProduct(Guid id, string name, string description, decimal price);
        Task<Guid> DeleteProduct(Guid productId);
        Task<List<Product>> GetAllProducts();
    }
}
