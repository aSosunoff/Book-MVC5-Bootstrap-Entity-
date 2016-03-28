using FirstMVC5App.Model.Business.Interface;
using FirstMVC5App.Model.Engine.Repository.Interface;
using FirstMVC5App.Model.Models;
using FirstMVC5App.Model.Repository.Interface;

namespace FirstMVC5App.Model.Engine.Business.Logic
{
    class HistoryBusinessLogic : IHistoryBusinessLogic
    {
        private readonly IHistoryRepository HistoryRepository;
        public HistoryBusinessLogic(IHistoryRepository historyRepository)
        {
            HistoryRepository = historyRepository;
        }
        public void AddBook(APP_BOOK item)
        {
            APP_HISTORY appHistory = new APP_HISTORY()
            {
                ID_BOOK = item.ID,
                OPERATION = "Added"
            };
            HistoryRepository.Create(appHistory);
        }

        public void UpdateBook(APP_BOOK item)
        {
            APP_HISTORY appHistory = new APP_HISTORY()
            {
                ID_BOOK = item.ID,
                OPERATION = "Update"
            };
            HistoryRepository.Create(appHistory);
        }

        public void DeleteBook(APP_BOOK item)
        {
            APP_HISTORY appHistory = new APP_HISTORY()
            {
                ID_BOOK = item.ID,
                OPERATION = "Delete"
            };
            HistoryRepository.Create(appHistory);
        }
    }
}
