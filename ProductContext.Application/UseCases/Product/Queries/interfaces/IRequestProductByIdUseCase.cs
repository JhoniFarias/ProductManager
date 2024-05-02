using ProductContext.Application.DTOs;

namespace ProductContext.Application.UseCases.Product.Queries.interfaces
{
    public interface IRequestProductByIdUseCase
    {
        Task<ProductDto> Handle(long id);

        void Validate(Domain.Entities.Product product);
    }
}
