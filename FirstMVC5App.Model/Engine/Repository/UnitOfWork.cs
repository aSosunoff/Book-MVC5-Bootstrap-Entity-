using System;
using System.Collections.Generic;
using FirstMVC5App.Model.Engine.Repository.Interface;
using FirstMVC5App.Model.Models;
using FirstMVC5App.Model.Repository.Entity;
using FirstMVC5App.Model.Repository.Interface;

namespace FirstMVC5App.Model.Engine.Repository
{
    public class UnitOfWork : EngineObject, IUnitOfWork
    {
        private Entities _entityDB = new Entities();

        //private Dictionary<Type, Object> _repositories = new Dictionary<Type, Object>();
        public UnitOfWork()
        {
            Objects.Add(typeof(IBookRepository), new BookRepository(_entityDB));
            Objects.Add(typeof(IHistoryRepository), new HistoryRepository(_entityDB));
        }

        //public T GetRepository<T>()
        //{
        //    Type repositoryType = typeof(T);

        //    if (_repositories.ContainsKey(repositoryType))
        //        return (T)_repositories[repositoryType];

        //    throw new Exception("Key for repository is not found");
        //}
        //private bool _disposed;

        //public override void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            _entityDB.Dispose();
        //        }
        //        _disposed = true;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
