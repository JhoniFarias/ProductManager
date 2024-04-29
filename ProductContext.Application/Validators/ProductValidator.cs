using FluentValidation;
using ProductContext.Communication.Dtos;

namespace ProductContext.Shared.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ManufactureDate).LessThan(p => p.ExpirationDate).WithMessage("A data de fabricação precisa ser menor que a data de validade");
            RuleFor(p => p.SuplierId).NotNull().GreaterThan(0).WithMessage("SuplierId - Necessário código de um fornecedor válido");
        }


    }
}
