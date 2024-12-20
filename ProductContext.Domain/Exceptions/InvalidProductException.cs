﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Domain
{
    public class InvalidProductException : Exception
    {
        public IEnumerable<string> Errors { get; private set; }
        public InvalidProductException(IEnumerable<string> messages) : base("Produto Invalido")
        {
            Errors = messages;
        }

        public InvalidProductException(string message)
        {
            Errors = new List<string>() { message };
        }
    }
}
