using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Shared.Exceptions
{
    public class InvalidProductException : Exception
    {
        public IEnumerable<string> Errors { get; private set; }
        public InvalidProductException(IEnumerable<string> messages) 
        {
            Errors = messages;
        }

        public InvalidProductException(string message)
        {
            Errors = new List<string>() { message };
        }
    }
}
