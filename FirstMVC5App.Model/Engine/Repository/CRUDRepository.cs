using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FirstMVC5App.Model.Repository.Interface;

namespace FirstMVC5App.Model.Repository
{
    public class CRUDRepository<T, TDb> : ICRUDRepository<T>
        where T : class
        where TDb : DbContext, new()
    {
        protected TDb Db;
        public CRUDRepository(TDb entities)
        {
            Db = entities;
        }
        public void Create(T item)
        {
            Db.Entry(item).State = EntityState.Added;
            //Db.Set<T>().Add(item);
            Db.SaveChanges();
        }

        public IEnumerable<T> GetList()
        {
            return Db.Set<T>().ToList();
        }

        public T GetItem(params object[] keyValue)
        {
            return Db.Set<T>().Find(keyValue);
        }

        public void Update(T item)
        {
            //todo: проверить как работает
            Db.Entry(item).State = EntityState.Modified;
            Db.SaveChanges();
            //Db.Entry(Db.Set<T>().Find(item));
            //Db.SaveChanges();
        }

        public void Delete(T item)
        {
            Db.Entry(item).State = EntityState.Deleted;
            //Db.Set<T>().Remove(item);
            Db.SaveChanges();
        }
    }
}
