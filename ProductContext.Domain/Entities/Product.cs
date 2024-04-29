using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Domain.Entities
{
    public class Product : Entity
    {
        protected Product() { }

        public Product(string description, bool isActive, DateTime manufactureDate, DateTime expirationDate, Suplier suplier)
        {
            Description = description;
            IsActive = isActive;
            ManufactureDate = manufactureDate;
            ExpirationDate = expirationDate;
            Suplier = suplier;
        }

        public string Description { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime ManufactureDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public virtual long SuplierId { get; private set; }

        [ForeignKey("SuplierId")]
        public virtual Suplier Suplier { get; private set; }


        public void Disable() => this.IsActive = false;
    }
}
