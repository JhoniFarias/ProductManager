using ProductContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(long id);

        Task<Product> RegisterAsync(Product product);

        Task UpdateAsync(Product productUpdated);

        Task Disable(long id);
    }
}
