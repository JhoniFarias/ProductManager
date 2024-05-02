using ProductContext.Application.DTOs;

namespace ProductContext.Application.UseCases.Product.Queries.interfaces
{
    public interface IRequestProductByFilterUseCase
    {
        Task<IEnumerable<ResponseProductDto>> Handle(RequestProductDto request);
    }
}
