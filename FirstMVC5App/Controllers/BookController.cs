using System.Collections.Generic;
using System.Web.Mvc;
using FirstMVC5App.Model.Engine.Servise.Interface;
using FirstMVC5App.Model.Models;
using Newtonsoft.Json;

namespace FirstMVC5App.Controllers
{
    public class BookController : Controller
    {
        private IServiceLayer ServiceLayer { get; set; }

        public BookController(IServiceLayer serviceLayer)
        {
            ServiceLayer = serviceLayer;
        }
        public ActionResult Index()
        {
            return View(ServiceLayer.Get<IBookService>().GetList());
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
                ServiceLayer.Get<IBookService>().Create(book);

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

            if (ServiceLayer.Get<IBookService>().IsElement(id))
                return View(ServiceLayer.Get<IBookService>().GetItem(id));

            return HttpNotFound();//todo: заменить на свою страницу ошибки
        }

        public ActionResult DetailsPartial(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Book");

            if (ServiceLayer.Get<IBookService>().IsElement(id))
                return PartialView(ServiceLayer.Get<IBookService>().GetItem(id));

            return HttpNotFound();//todo: заменить на свою страницу ошибки сообщить, что нет такой книги
        }
        // УБРАТЬ ПОВТОРЕНИЕ КОДА

        public ActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Book");//return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //APP_BOOK aPP_BOOK = db.APP_BOOK.Find(id);
            //if (aPP_BOOK == null)
            //{
            //    return HttpNotFound();
            //}
            if (ServiceLayer.Get<IBookService>().IsElement(id))
                return View(ServiceLayer.Get<IBookService>().GetItem(id));
            return HttpNotFound();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(APP_BOOK book)//([Bind(Include = "ID,NAME,GANRE,PRICE")] APP_BOOK aPP_BOOK)
        {
            if (ModelState.IsValid)
            {
                ServiceLayer.Get<IBookService>().Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Book");//return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            if (ServiceLayer.Get<IBookService>().IsElement(id))
                return View(ServiceLayer.Get<IBookService>().GetItem(id));
            return HttpNotFound();
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteId(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Book");

            ServiceLayer.Get<IBookService>().Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            ServiceLayer.Dispose();
            //todo: Возможно надо добавить и на остальных уровнях
            base.Dispose(disposing);
        }


        #region Test JSON
        [HttpPost]
        public string GetBooks()
        {
            return JsonConvert.SerializeObject(ServiceLayer.Get<IBookService>().GetList());
            //return Json(ServiceLayer.Get<IBookService>().GetList(), JsonRequestBehavior.AllowGet);
            //Просмотреть что за функция
        }

        [HttpPost]
        public void SetBooks(string data)
        {
            IEnumerable<APP_BOOK> books = JsonConvert.DeserializeObject<IEnumerable<APP_BOOK>>(data);
        }
        #endregion
    }
}
