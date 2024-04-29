using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductContext.Shared.Exceptions
{
    public class NotFoundProductException : Exception
    {

        public NotFoundProductException(string message) : base(message)
        {}
    }
}
