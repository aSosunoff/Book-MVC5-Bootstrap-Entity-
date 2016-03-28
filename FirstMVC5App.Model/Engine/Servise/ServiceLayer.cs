using System;
using System.Collections.Generic;
using FirstMVC5App.Model.Business;
using FirstMVC5App.Model.Engine.Business;
using FirstMVC5App.Model.Engine.Servise.Interface;
using FirstMVC5App.Model.Engine.Servise.Logic;

namespace FirstMVC5App.Model.Engine.Servise
{
    public class ServiceLayer : EngineObject, IServiceLayer
    {
        public ServiceLayer(IBusinessLayer busenessLayer)
        {
            Objects.Add(typeof(IBookService), new BookService(busenessLayer));
        }      
    }

}
