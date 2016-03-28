using FirstMVC5App.Model.Models;
using FirstMVC5App.Model.Repository.Interface;

namespace FirstMVC5App.Model.Repository.Entity
{
    public class BookRepository : CRUDRepository<APP_BOOK, Entities>, IBookRepository
    {
        public BookRepository(Entities entities) : base(entities)
        {
            
        }
    }
}
