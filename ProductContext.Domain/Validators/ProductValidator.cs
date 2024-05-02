using FluentValidation;
using ProductContext.Domain.Entities;

namespace ProductContext.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ManufactureDate.Date).LessThan(p => p.ExpirationDate.Date).WithMessage("A data de fabricação precisa ser menor que a data de validade");
            RuleFor(p => p.SuplierId).NotNull().GreaterThan(0).WithMessage("SuplierId - Necessário código de um fornecedor válido");
        }


    }
}
