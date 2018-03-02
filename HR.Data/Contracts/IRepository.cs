
using System;
using System.Collections.Generic;
using System.Linq;
namespace HR.Data.Contracts
{
    public interface IRepository<T>
    {
        void Insert(T entity);

        void Delete(T entity);

        void Update(T entity);

        List<T> Search(Func<T, bool> predicate);

        List<T> GetAll();

        T GetById(long id);
    }
}
