namespace ProductContext.Application.DTOs
{
    public class ResponseProductDto
    {
        public long Id { get; set; }
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Suplier Suplier { get; set; }

    }

    public class Suplier
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string CNPJ { get; set; } = null!;
    }


}
