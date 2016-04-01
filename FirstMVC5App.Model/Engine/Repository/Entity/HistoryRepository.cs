using FirstMVC5App.Model.Engine.Repository.Interface;
using FirstMVC5App.Model.Models;
using FirstMVC5App.Model.Repository;

namespace FirstMVC5App.Model.Engine.Repository.Entity
{
    public class HistoryRepository : CRUDRepository<APP_HISTORY, Entities>, IHistoryRepository
    {
        public HistoryRepository(Entities entities) : base(entities){}
    }
}
