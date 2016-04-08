﻿using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMVC5App.Component;
using FirstMVC5App.Model.Engine.Servise;
using FirstMVC5App.Model.Engine.Servise.Interface;
using FirstMVC5App.Model.Models;
using Newtonsoft.Json;

namespace FirstMVC5App.Controllers
{
    public class BookController : Controller
    {
        private IServiceLayer _ServiceLayer { get; set; }

        public BookController(IServiceLayer serviceLayer)
        {
            _ServiceLayer = ServiceLayer.Instance(serviceLayer); 
        }   

        public ActionResult Index( Sort sortModel = null, int page = 1)
        {
            IEnumerable<APP_BOOK> books = _ServiceLayer.Get<IBookService>().GetList();

            PaginatorModelSort<APP_BOOK> paginatorModelSort = new PaginatorModelSort<APP_BOOK>(3, page, sortModel, books);

            //PaginatorModel<APP_BOOK> paginatorModel = new PaginatorModel<APP_BOOK>(3, page, books);

            return View(paginatorModelSort);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,NAME,GANRE,PRICE")] APP_BOOK aPP_BOOK)
        public ActionResult Create(APP_BOOK book)
        {
            if (ModelState.IsValid)
            {
                _ServiceLayer.Get<IBookService>().Create(book);

                return RedirectToAction("Index");
            }
            //else
            //{
            //    if (this.ModelState["PRICE"].Errors.Count == 1)
            //    {
            //        this.ModelState["PRICE"].Errors.Clear();
            //        this.ModelState["PRICE"].Errors.Add("Invalid PRICE.");
            //    }
            //}

            return View(book);
        }

        // TODO: УБРАТЬ ПОВТОРЕНИЕ КОДА
        public ActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Book");

            if (_ServiceLayer.Get<IBookService>().IsElement(id))
                return View(_ServiceLayer.Get<IBookService>().GetItem(id));

            return HttpNotFound();//todo: заменить на свою страницу ошибки
        }

        public ActionResult DetailsPartial(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Book");

            if (_ServiceLayer.Get<IBookService>().IsElement(id))
                return PartialView(_ServiceLayer.Get<IBookService>().GetItem(id));

            return HttpNotFound();//todo: заменить на свою страницу ошибки сообщить, что нет такой книги
        }
        // УБРАТЬ ПОВТОРЕНИЕ КОДА

        public ActionResult Edit(int? id)
        {//todo: пофиксить загрузку старого изображения когда идём на правку
            if (id == null) return RedirectToAction("Index", "Book");//return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //APP_BOOK aPP_BOOK = db.APP_BOOK.Find(id);
            //if (aPP_BOOK == null)
            //{
            //    return HttpNotFound();
            //}
            if (_ServiceLayer.Get<IBookService>().IsElement(id))
                return View(_ServiceLayer.Get<IBookService>().GetItem(id));
            return HttpNotFound();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(APP_BOOK book)//([Bind(Include = "ID,NAME,GANRE,PRICE")] APP_BOOK aPP_BOOK)
        {
            if (ModelState.IsValid)
            {
                _ServiceLayer.Get<IBookService>().Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Book");//return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            if (_ServiceLayer.Get<IBookService>().IsElement(id))
                return View(_ServiceLayer.Get<IBookService>().GetItem(id));
            return HttpNotFound();
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteId(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Book");

            _ServiceLayer.Get<IBookService>().Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _ServiceLayer.Dispose();
            //todo: Возможно надо добавить и на остальных уровнях
            base.Dispose(disposing);
        }

        #region Test JSON
        [HttpPost]
        public string GetBooks()
        {
            //todo: Прочитать что такое. Было изменено потому что JSON выкидывал исключение с циключной ссылкой
            JsonSerializerSettings jsSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(_ServiceLayer.Get<IBookService>().GetList(), Formatting.None, jsSettings);

            //return Json(ServiceLayer.Get<IBookService>().GetList(), JsonRequestBehavior.AllowGet);
            //todo: Просмотреть что за функция
        }

        [HttpPost]
        public void SetBooks(string data)
        {
            IEnumerable<APP_BOOK> books = JsonConvert.DeserializeObject<IEnumerable<APP_BOOK>>(data);
        }
        #endregion
    }
}
