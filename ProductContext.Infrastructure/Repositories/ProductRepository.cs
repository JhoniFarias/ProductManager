using Microsoft.EntityFrameworkCore;
using ProductContext.Domain.Entities;
using ProductContext.Domain.Repositories;

namespace ProductContext.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Product?> GetByIdAsync(long id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Product> RegisterAsync(Product product)
        {
           _context.Products.Add(product);
           await _context.SaveChangesAsync();

           return product;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task Disable(long id)
        {

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                product.Disable();
                _context.Update(product);
                await _context.SaveChangesAsync();
            }


        }
    }
}
