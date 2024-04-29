using AutoMapper;
using ProductContext.Communication.Dtos;
using ProductContext.Domain.Entities;

namespace ProductContext.API.Automapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.CNPJ, m => m.MapFrom(m => m.Suplier.CNPJ))
                .ForMember(p => p.SuplierName, m => m.MapFrom(m => m.Suplier.Description));
        }
    }
}
