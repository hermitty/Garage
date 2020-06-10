using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Garage.Domain.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        T GetById(int id, string includeProperties = null);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
