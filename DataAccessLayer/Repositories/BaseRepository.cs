using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public abstract class BaseRepository<T>:IBaseRepository<T> where T:class
    {
        Model1 _ctx;
        public BaseRepository(Model1 ctx)
        {
            _ctx = ctx;
        }

        public virtual List<T> List()
        {
            List<T> result = _ctx.Set<T>().ToList();
            return result;
        }

        public virtual void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
        }

        public virtual T Find(int id)
        {
            T result = _ctx.Set<T>().Find(id);
            return result;

        }

        public virtual void Delete(int id)
        {
            T entity = Find(id);
            _ctx.Set<T>().Remove(entity);
            _ctx.SaveChanges();
        }

    }
}
