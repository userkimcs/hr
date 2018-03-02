using HR.Data.Contracts;
using HR.Data.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HR.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IApplicationDbContext _context;

        public Repository(IApplicationDbContext _context)
        {
            this._context = _context;
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified; 
            _context.SaveChanges();
        }

        public List<T> Search(System.Func<T,bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }


        public T GetById(long id)
        {
            return this._context.Set<T>().FirstOrDefault(t => t.Id == id);
        }
    }
}
