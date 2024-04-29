using AutoMapper;
using ProductContext.Communication.Dtos;
using ProductContext.Domain.Repositories;
using ProductContext.Shared.Exceptions;

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
