using AutoMapper;
using ProductContext.Domain.Repositories;
using ProductContext.Application.DTOs;
using ProductContext.Domain.Validators;
using ProductContext.Domain;
using ProductContext.Application.UseCases.Product.Commands.interfaces;

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
            return await _productRepository.RegisterAsync(product);
        }
    }
}
