

using HR.Data.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace HR.Data.Contracts
{
    public interface IApplicationDbContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
        DbEntityEntry Entry(BaseEntity entity);
    }
}
