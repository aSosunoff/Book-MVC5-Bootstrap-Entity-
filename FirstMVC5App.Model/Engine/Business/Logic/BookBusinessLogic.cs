using System;
using System.Collections.Generic;
using System.Linq;
using FirstMVC5App.Model.Engine.Business.Interface;
using FirstMVC5App.Model.Models;
using FirstMVC5App.Model.Repository.Interface;

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
            return id != null && _bookRepository.GetItem(id) != null;
        }

        public void Update(APP_BOOK item)
        {
            item.DATE_UPDATE = DateTime.Now;
            _bookRepository.Update(item);
        }

        public void Delete(APP_BOOK item)
        {
            _bookRepository.Delete(item);
        }
    }
}
