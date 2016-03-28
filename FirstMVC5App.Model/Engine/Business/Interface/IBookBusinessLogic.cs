using System.Collections.Generic;
using FirstMVC5App.Model.Models;

namespace FirstMVC5App.Model.Engine.Business.Interface
{
    public interface IBookBusinessLogic
    {
        IEnumerable<APP_BOOK> GetBooks();
        APP_BOOK GetBook(int? id);
        void CreateBook(APP_BOOK appBook);
        bool IsElement(int? id);
        void Update(APP_BOOK item);
        void Delete(APP_BOOK item);
    }
}