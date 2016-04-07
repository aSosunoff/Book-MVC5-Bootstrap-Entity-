using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstMVC5App.Model.Engine.Repository.Interface;
using FirstMVC5App.Model.Engine.Servise.Interface;
using FirstMVC5App.Model.Models;

namespace FirstMVC5App.Model.Engine.Servise.Logic
{
    class HistoryService : BaseService, IHistoryService
    {
        private IHistoryRepository _historyRepository;
        public HistoryService(IUnitOfWork unitOfWork)
        {
            _historyRepository = unitOfWork.Get<IHistoryRepository>();
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
