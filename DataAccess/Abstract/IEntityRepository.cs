using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        List<T> GetAll(Expression<Func<bool,T>> filter=null);
        T Get(Expression<Func<bool, T>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
