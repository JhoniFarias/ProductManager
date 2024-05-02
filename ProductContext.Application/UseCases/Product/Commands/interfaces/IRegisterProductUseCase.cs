using ProductContext.Application.DTOs;

namespace ProductContext.Application.UseCases.Product.Commands.interfaces
{
    public interface IRegisterProductUseCase
    {
        Task<Domain.Entities.Product> Handle(ProductDto productDto);
    }
}
