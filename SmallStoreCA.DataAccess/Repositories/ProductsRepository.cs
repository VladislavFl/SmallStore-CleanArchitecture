using Microsoft.EntityFrameworkCore;
using SmallStore.Core.Models;
using SmallStoreCA.DataAccess.Entities;

namespace SmallStoreCA.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private StoreDbContext _context;

        public ProductsRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Get()
        {
            var productEntities = await _context.Products
                .AsNoTracking()
                .ToListAsync();

            var products = productEntities
                .Select(x => Product.Create(x.Id, x.Name, x.Description, x.Price).Product)
                .ToList();

            return products;
        }

        public async Task<Guid> Create(Product product)
        {
            var productEntity = new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            return productEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string description, decimal price)
        {
            await _context.Products
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, b => name)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.Price, b => price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Products
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
