using System.Collections.Generic;
using FirstMVC5App.Model.Models;

namespace FirstMVC5App.Model.Engine.Servise.Interface
{
    public interface IBookService
    {
        IEnumerable<APP_BOOK> GetList();
        void Create(APP_BOOK item);
        APP_BOOK GetItem(int? id);
        bool IsElement(int? id);
        void Update(APP_BOOK item);
        void Delete(int? id);
    }
}