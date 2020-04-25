using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EntityFrameWork.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(); T SingleOrDefault(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
    }
}

