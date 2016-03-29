using System.Collections.Generic;
using FirstMVC5App.Model.Business;
using FirstMVC5App.Model.Business.Interface;
using FirstMVC5App.Model.Engine.Business;
using FirstMVC5App.Model.Engine.Business.Interface;
using FirstMVC5App.Model.Engine.Servise.Interface;
using FirstMVC5App.Model.Models;

namespace FirstMVC5App.Model.Engine.Servise.Logic
{
    public class BookService : BaseService, IBookService
    {
        public BookService(IBusinessLayer businessLayer) : base(businessLayer){}
        public IEnumerable<APP_BOOK> GetList()
        {
            return BusinessLayer.Get<IBookBusinessLogic>().GetBooks();
        }

        public void Create(APP_BOOK item)
        {
            BusinessLayer.Get<IBookBusinessLogic>().CreateBook(item);
            BusinessLayer.Get<IHistoryBusinessLogic>().AddBook(item);
        }

        public APP_BOOK GetItem(int? id)
        {
            return BusinessLayer.Get<IBookBusinessLogic>().GetBook(id);
        }

        public bool IsElement(int? id)
        {
            return BusinessLayer.Get<IBookBusinessLogic>().IsElement(id);
        }

        public void Update(APP_BOOK item)
        {
            BusinessLayer.Get<IBookBusinessLogic>().Update(item);
            BusinessLayer.Get<IHistoryBusinessLogic>().UpdateBook(item);
        }

        public void Delete(int? id)
        {
            APP_BOOK appBook = GetItem(id);
            BusinessLayer.Get<IHistoryBusinessLogic>().DeleteBook(appBook);
            BusinessLayer.Get<IBookBusinessLogic>().Delete(appBook);
        }
    }
}
