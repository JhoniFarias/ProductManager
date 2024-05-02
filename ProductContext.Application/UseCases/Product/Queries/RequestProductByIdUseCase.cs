using AutoMapper;
using ProductContext.Application.DTOs;
using ProductContext.Application.UseCases.Product.Queries.interfaces;
using ProductContext.Domain;
using ProductContext.Domain.Repositories;


namespace ProductContext.Application.UseCases.Product.Queries
{
    public class RequestProductByIdUseCase : IRequestProductByIdUseCase
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
        public RequestProductByIdUseCase(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(long id)
        {

            Domain.Entities.Product? product = await _productRepository.GetByIdAsync(id);
            Validate(product);

            ProductDto productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public void Validate(Domain.Entities.Product? product)
        {

            if (product == null)
            {
                throw new NotFoundProductException("Produto não encontrado");
            }
        }
    }
}
