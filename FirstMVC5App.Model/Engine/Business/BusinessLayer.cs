﻿using System;
using System.Collections.Generic;
using FirstMVC5App.Model.Business;
using FirstMVC5App.Model.Business.Interface;
using FirstMVC5App.Model.Engine.Business.Interface;
using FirstMVC5App.Model.Engine.Business.Logic;
using FirstMVC5App.Model.Engine.Repository.Interface;
using FirstMVC5App.Model.Repository.Interface;

namespace FirstMVC5App.Model.Engine.Business
{
    public class BusinessLayer : EngineObject, IBusinessLayer
    {
        public BusinessLayer(IUnitOfWork unitOfWork)
        {
            Objects.Add(typeof(IBookBusinessLogic), new BookBusinessLogic(unitOfWork.Get<IBookRepository>()));
            Objects.Add(typeof(IHistoryBusinessLogic), new HistoryBusinessLogic(unitOfWork.Get<IHistoryRepository>()));
        }   
    }
}
