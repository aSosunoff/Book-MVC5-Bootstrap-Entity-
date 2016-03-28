using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVC5App.Component.Exception
{
    public class ExceptionBook : RootApplicationException
    {
        public ExceptionBook(string message) : base(message){}
    }
}