using ProductContext.Infrastructure;
using AspNetCore.IQueryable.Extensions;
using Microsoft.EntityFrameworkCore;
using ProductContext.Communication.Dtos;
using AutoMapper;
using ProductContext.Domain.Entities;

namespace ProductContext.Application.UseCases.Product.Queries
{
    public class RequestProductByFilterUseCase : IRequestProductByFilterUseCase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RequestProductByFilterUseCase(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(RequestProductDto request)
        {
            IQueryable<Domain.Entities.Product> query = _context.Products.Include(a => a.Suplier);

            if (!string.IsNullOrWhiteSpace(request.Description))
                query = query.Where(p => p.Description.Contains(request.Description));

            if (request.IsActive.HasValue)
                query = query.Where(p => p.IsActive == request.IsActive.Value);

            if (request.ManufactureDate.HasValue)
                query = query.Where(p => p.ManufactureDate >= request.ManufactureDate.Value);

            if (request.ExpirationDate.HasValue)
                query = query.Where(p => p.ExpirationDate <= request.ExpirationDate.Value);

            if (!string.IsNullOrWhiteSpace(request.SuplierName))
                query = query.Where(p => p.Suplier.Description.Contains(request.SuplierName));

            if (!string.IsNullOrWhiteSpace(request.CNPJ))
                query = query.Where(p => p.Suplier.CNPJ == request.CNPJ);

            if (request.Offset.HasValue)
                query = query.Skip(request.Offset.Value);

            List<Domain.Entities.Product> products = await query.Take(request.Limit.Value).ToListAsync();

            return products.Select(_mapper.Map<ProductDto>);
        }
    }
}
