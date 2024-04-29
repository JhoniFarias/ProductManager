
namespace ProductContext.Communication.Dtos
{
    public class ProductDto
    {   
        public long Id { get; set; }
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SuplierId { get; set; }
        public string SuplierName { get; set; } = null!;
        public string CNPJ { get; set; } = null!;


    }
}
