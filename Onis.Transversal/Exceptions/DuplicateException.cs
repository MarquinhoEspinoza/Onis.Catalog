using System;
using System.Collections.Generic;
using System.Text;

namespace Onis.Transversal.Exceptions
{
    public class DuplicateException : Exception
    {
        public DuplicateException(string message) : base(message)
        {

        }

    }
}
