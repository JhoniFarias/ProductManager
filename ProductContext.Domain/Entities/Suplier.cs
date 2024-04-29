using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Domain.Entities
{
    public class Suplier : Entity
    {
        protected Suplier() { }

        public Suplier(string description, string cnpj)
        {
            Description = description;
            CNPJ = cnpj;
        }

        public string Description { get; private set; }

        [MaxLength(14)]
        public string CNPJ { get; private set; }
    }
}
