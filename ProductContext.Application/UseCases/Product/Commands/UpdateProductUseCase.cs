using AutoMapper;
using ProductContext.Domain.Repositories;
using ProductContext.Domain;
using ProductContext.Application.DTOs;
using ProductContext.Domain.Validators;
using FluentValidation;
using ProductContext.Application.UseCases.Product.Commands.interfaces;

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

            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new InvalidProductException("O produto não existe");
            }

        }
    }
}
