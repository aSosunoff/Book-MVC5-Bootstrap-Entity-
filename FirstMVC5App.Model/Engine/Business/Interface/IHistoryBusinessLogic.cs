using FirstMVC5App.Model.Models;

namespace FirstMVC5App.Model.Business.Interface
{
    public interface IHistoryBusinessLogic
    {
        void AddBook(APP_BOOK item);
        void UpdateBook(APP_BOOK item);
        void DeleteBook(APP_BOOK item);
    }
}