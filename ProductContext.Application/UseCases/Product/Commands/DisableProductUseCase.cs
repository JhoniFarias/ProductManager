using ProductContext.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Application.UseCases.Product.Commands
{
    public class DisableProductUseCase : IDisableProductUseCase
    {
        private readonly IProductRepository _productRepository;
        public DisableProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(long id)
        {
            await _productRepository.Disable(id);
        }
    }
}
