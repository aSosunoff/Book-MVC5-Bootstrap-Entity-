using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVC5App.Component.Exception
{
    public class RootApplicationException : ApplicationException
    {
        public RootApplicationException(string message) : base(message) { }
    }
}