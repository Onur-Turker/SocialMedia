using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IBaseRepository<T> where T:class
    {
        List<T> List();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        T Find(int id);
        
    }
}
