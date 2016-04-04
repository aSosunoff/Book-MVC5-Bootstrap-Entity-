using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using FirstMVC5App.Model.Engine.Business.Interface;
using FirstMVC5App.Model.Engine.Repository.Interface;
using FirstMVC5App.Model.Models;

namespace FirstMVC5App.Model.Engine.Business.Logic
{
    public class BookBusinessLogic : IBookBusinessLogic
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IBookRepository _bookRepository;
        public BookBusinessLogic(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            //_unitOfWork = unitOfWork;
        }
        public IEnumerable<APP_BOOK> GetBooks()
        {
            return _bookRepository.GetList().OrderByDescending(x => x.DATE_REG);
        }

        public APP_BOOK GetBook(int? id)
        {
            return _bookRepository.GetItem(id);
        }

        public void CreateBook(APP_BOOK appBook)
        {
            appBook.DATE_REG = DateTime.Now;
            _bookRepository.Create(appBook);
        }

        public bool IsElement(int? id)
        {
            return id != null && GetBook(id) != null;
        }

        public void Update(APP_BOOK item)
        {
            item.DATE_UPDATE = DateTime.Now;
            _bookRepository.Update(item);
        }

        public void Delete(APP_BOOK item)
        {
            //:todo имя файла по дефолту употребляется строкой уже 2 раз. Необходимо обойти это что бы не ошибиться при написании
            string filePath = String.IsNullOrEmpty(item.IMG_FILE_PATH) ? String.Empty : Path.Combine(HttpContext.Current.Server.MapPath(item.IMG_FILE_PATH));
            if (File.Exists(filePath) && Path.GetFileName(filePath) != "default.png")
                File.Delete(filePath);
            _bookRepository.Delete(item);
        }
    }
}
