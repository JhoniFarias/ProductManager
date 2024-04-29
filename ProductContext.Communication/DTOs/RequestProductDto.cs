using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Pagination;

namespace ProductContext.Communication.Dtos
{
    public class RequestProductDto
    {
        public string? Description { get; set; } = null;
        public bool? IsActive { get; set; } = null;
        public DateTime? ManufactureDate { get; set; } = null;
        public DateTime? ExpirationDate { get; set; } = null;
        public string? SuplierName { get; set; }

        public string? CNPJ { get; set; } = null;
        public int? Limit { get; set; } = 20;
        public int? Offset { get; set; }
    }
}
