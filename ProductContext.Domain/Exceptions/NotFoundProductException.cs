using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductContext.Domain
{
    public class NotFoundProductException : Exception
    {

        public NotFoundProductException(string message) : base(message)
        {}
    }
}
