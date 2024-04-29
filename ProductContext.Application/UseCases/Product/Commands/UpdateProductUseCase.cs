using AutoMapper;
using ProductContext.Domain.Repositories;
using ProductContext.Shared.Validators;
using ProductContext.Shared.Exceptions;
using ProductContext.Communication.Dtos;
using ProductContext.Domain.Entities;
using ProductContext.Infrastructure.Repositories;
using Org.BouncyCastle.Utilities;

namespace ProductContext.Application.UseCases.Product.Commands
{
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
        public UpdateProductUseCase(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Product> Handle(long id,ProductDto productDto)
        {
            await Validate(id, productDto);

            var product = _mapper.Map<Domain.Entities.Product>(productDto);

            await _productRepository.UpdateAsync(product);

            return product;
        }

        public async Task Validate(long id, ProductDto productDto)
        {
            var validator = new ProductValidator();
            var result = validator.Validate(productDto);

            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new InvalidProductException("O produto não existe");
            }

            if (!result.IsValid)
            {
                throw new InvalidProductException(result.Errors.Select(p => p.ErrorMessage));
            }


        }
    }
}
