using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using FirstMVC5App.Model.Engine.Repository.Interface;
using FirstMVC5App.Model.Engine.Servise.Interface;
using FirstMVC5App.Model.Models;

namespace FirstMVC5App.Model.Engine.Servise.Logic
{
    public class BookService : BaseService, IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IUnitOfWork unitOfWork)
        {
            _bookRepository = unitOfWork.Get<IBookRepository>();
        }

        public IEnumerable<APP_BOOK> GetList()
        {
            return _bookRepository.GetAllList();
        }

        public void Create(APP_BOOK item)
        {
            item.DATE_REG = DateTime.Now;
            _bookRepository.Create(item);
            RootServiceLayer.Get<IHistoryService>().AddBook(item);
        }

        public APP_BOOK GetItem(int? id)
        {
            return _bookRepository.GetItem(id);
        }

        public bool IsElement(int? id)
        {
            return id != null && GetItem(id) != null;
        }

        public void Update(APP_BOOK item)
        {
            item.DATE_UPDATE = DateTime.Now;
            _bookRepository.Update(item);
            RootServiceLayer.Get<IHistoryService>().UpdateBook(item);
        }

        public void Delete(int? id)
        {
            APP_BOOK appBook = GetItem(id);

            RootServiceLayer.Get<IHistoryService>().DeleteBook(appBook);

            //:todo имя файла по дефолту употребляется строкой уже 2 раз. Необходимо обойти это что бы не ошибиться при написании
            string filePath = String.IsNullOrEmpty(appBook.IMG_FILE_PATH) ? String.Empty : Path.Combine(HttpContext.Current.Server.MapPath(appBook.IMG_FILE_PATH));
            if (File.Exists(filePath) && Path.GetFileName(filePath) != "default.png")
                File.Delete(filePath);
            _bookRepository.Delete(appBook);

        }



    }
}
