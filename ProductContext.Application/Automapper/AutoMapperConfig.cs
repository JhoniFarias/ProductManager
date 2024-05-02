using AutoMapper;
using ProductContext.Application.DTOs;
using ProductContext.Domain.Entities;

namespace ProductContext.API.Automapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ProductDto, Product>()
                .ConstructUsing(x => new Product(x.Description, x.ManufactureDate, x.ExpirationDate, x.SuplierId, x.IsActive));

            CreateMap<Product, ResponseProductDto>()
                 .ForPath(p => p.Suplier.Id, m => m.MapFrom(m => m.Suplier.Id))
                 .ForPath(p => p.Suplier.CNPJ, m => m.MapFrom(m => m.Suplier.CNPJ))
                 .ForPath(p => p.Suplier.Description, m => m.MapFrom(m => m.Suplier.Description));
        }
    }
}
