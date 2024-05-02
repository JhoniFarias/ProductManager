using ProductContext.Domain.Validators;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductContext.Domain.Entities
{
    public class Product : Entity
    {
        protected Product(){}

        public Product(string description, DateTime manufactureDate, DateTime expirationDate, long suplierId, bool isActive = true)
        {
            Description = description;
            IsActive = isActive;
            ManufactureDate = manufactureDate;
            ExpirationDate = expirationDate;
            SuplierId = suplierId;

            Validate();
        }

        public string Description { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime ManufactureDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public virtual long SuplierId { get; private set; }

        [ForeignKey("SuplierId")]
        public virtual Supplier Suplier { get; private set; }


        public void Disable() => this.IsActive = false;

        private void Validate()
        {
            var result = new ProductValidator().Validate(this);

            if (!result.IsValid)
                throw new InvalidProductException(result.Errors.Select(p => p.ErrorMessage));
        }
    }
}
