using ProductContext.Communication.Dtos;

namespace ProductContext.Application.UseCases.Product.Commands
{
    public interface IRegisterProductUseCase
    {
        Task<Domain.Entities.Product> Handle(ProductDto productDto);

        void Validate(ProductDto productDto);
    }
}
