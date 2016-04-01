using FirstMVC5App.Model.Business.Interface;
using FirstMVC5App.Model.Engine.Repository.Interface;
using FirstMVC5App.Model.Models;

namespace FirstMVC5App.Model.Engine.Business.Logic
{
    class HistoryBusinessLogic : IHistoryBusinessLogic
    {
        private readonly IHistoryRepository _historyRepository;
        public HistoryBusinessLogic(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }
        public void AddBook(APP_BOOK item)
        {
            APP_HISTORY appHistory = new APP_HISTORY()
            {
                ID_BOOK = item.ID,
                OPERATION = "Added"
            };
            _historyRepository.Create(appHistory);
        }

        public void UpdateBook(APP_BOOK item)
        {
            APP_HISTORY appHistory = new APP_HISTORY()
            {
                ID_BOOK = item.ID,
                OPERATION = "Update"
            };
            _historyRepository.Create(appHistory);
        }

        public void DeleteBook(APP_BOOK item)
        {
            APP_HISTORY appHistory = new APP_HISTORY()
            {
                ID_BOOK = item.ID,
                OPERATION = "Delete"
            };
            _historyRepository.Create(appHistory);
        }
    }
}
