using SmallStore.Core.Models;

namespace SmallStoreCA.DataAccess.Repositories
{
    public interface IProductsRepository
    {
        Task<Guid> Create(Product product);
        Task<Guid> Delete(Guid id);
        Task<List<Product>> Get();
        Task<Guid> Update(Guid id, string name, string description, decimal price);
    }
}