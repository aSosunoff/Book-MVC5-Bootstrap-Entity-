using FirstMVC5App.Model.Engine.Repository.Entity;
using FirstMVC5App.Model.Engine.Repository.Interface;
using FirstMVC5App.Model.Models;

namespace FirstMVC5App.Model.Engine.Repository
{
    public class UnitOfWork : Engine, IUnitOfWork
    {
        private readonly Entities _entityDb = new Entities();

        public UnitOfWork()
        {
            Objects.Add(typeof(IBookRepository), new BookRepository(_entityDb));
            Objects.Add(typeof(IHistoryRepository), new HistoryRepository(_entityDb));
        }
    }
}
