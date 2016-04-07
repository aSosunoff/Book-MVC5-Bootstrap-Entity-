using FirstMVC5App.Model.Models;

namespace FirstMVC5App.Model.Engine.Servise.Interface
{
    public interface IHistoryService : IBaseService
    {
        void AddBook(APP_BOOK item);
        void UpdateBook(APP_BOOK item);
        void DeleteBook(APP_BOOK item);
    }
}