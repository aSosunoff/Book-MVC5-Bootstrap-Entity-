using System.Collections.Generic;

namespace FirstMVC5App.Model.Engine.Repository.Interface
{
    public interface ICRUDRepository<T> where T : class
    {
        void Create(T item);
        IEnumerable<T> GetList();
        T GetItem(params object[] keyValye);
        void Update(T item);
        void Delete(T item);
    }
}