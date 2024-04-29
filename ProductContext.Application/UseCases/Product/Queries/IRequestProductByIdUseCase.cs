
using ProductContext.Communication.Dtos;

namespace ProductContext.Application.UseCases.Product.Queries
{
    public interface IRequestProductByIdUseCase
    {
        Task<ProductDto> Handle(long id);

        void Validate(Domain.Entities.Product product);
    }
}
