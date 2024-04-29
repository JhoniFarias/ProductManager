using ProductContext.Communication.Dtos;

namespace ProductContext.Application.UseCases.Product.Commands
{
    public interface IUpdateProductUseCase
    {
        Task<Domain.Entities.Product> Handle(long id,ProductDto productDto);

        Task Validate(long id, ProductDto productDto);
    }
}
