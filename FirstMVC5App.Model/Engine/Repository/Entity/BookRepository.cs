using FirstMVC5App.Model.Engine.Repository.Interface;
using FirstMVC5App.Model.Models;
using FirstMVC5App.Model.Repository;

namespace FirstMVC5App.Model.Engine.Repository.Entity
{
    public class BookRepository : CRUDRepository<APP_BOOK, Entities>, IBookRepository
    {
        public BookRepository(Entities entities) : base(entities){}
    }
}
