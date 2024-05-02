using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Application.UseCases.Product.Commands.interfaces
{
    public interface IDisableProductUseCase
    {
        Task Handle(long id);
    }
}
