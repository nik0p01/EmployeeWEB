using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWEB.Exceptions
{
    public class MyServerException : ApplicationException
    {
        public MyServerException() { }

        public MyServerException(string message) : base(message) { }

        public MyServerException(string message, Exception inner) : base(message, inner) { }

    }
}
