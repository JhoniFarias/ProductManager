using AutoMapper;
using ProductContext.Domain.Repositories;
using ProductContext.Shared.Validators;
using ProductContext.Shared.Exceptions;
using ProductContext.Communication.Dtos;

namespace ProductContext.Application.UseCases.Product.Commands
{
    public class RegisterProductUseCase : IRegisterProductUseCase
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
        public RegisterProductUseCase(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Product> Handle(ProductDto productDto)
        {
            var product = _mapper.Map<Domain.Entities.Product>(productDto);

            Validate(productDto);

            return await _productRepository.RegisterAsync(product);
        }

        public void Validate(ProductDto productDto)
        {
            var validator = new ProductValidator();
            var result = validator.Validate(productDto);

            if (!result.IsValid)
            {
                var errorMessage = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new InvalidProductException(errorMessage);
            }
        }
    }
}
