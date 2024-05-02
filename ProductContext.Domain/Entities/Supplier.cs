using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Domain.Entities
{
    public class Supplier : Entity
    {
        protected Supplier() { }

        public Supplier(string description, string cnpj)
        {
            Description = description;
            CNPJ = cnpj;
        }

        public string Description { get; private set; }

        [MinLength(14, ErrorMessage = "O CNPJ precisa ter 14 digitos")]
        [MaxLength(14,ErrorMessage = "CNPJ pode conter apenas 14 digitos")]
        public string CNPJ { get; private set; }
    }
}
