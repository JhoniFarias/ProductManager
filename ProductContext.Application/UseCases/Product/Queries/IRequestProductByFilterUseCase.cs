using ProductContext.Communication.Dtos;

namespace ProductContext.Application.UseCases.Product.Queries
{
    public interface IRequestProductByFilterUseCase
    {
        Task<IEnumerable<ProductDto>> Handle(RequestProductDto request);
    }
}
