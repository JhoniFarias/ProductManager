using ProductContext.Application.DTOs;

namespace ProductContext.Application.UseCases.Product.Commands.interfaces
{
    public interface IUpdateProductUseCase
    {
        Task<Domain.Entities.Product> Handle(long id, ProductDto productDto);

        Task Validate(long id, ProductDto productDto);
    }
}
