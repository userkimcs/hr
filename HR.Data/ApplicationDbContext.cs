

using HR.Data.Mapping;
using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using HR.Data.Contracts;
using System.Data.Entity.Infrastructure;
namespace HR.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("data source=(local);initial catalog=QLNS;integrated security=True;User Id=sa;Password=123456;")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : Entities.BaseEntity
        {
            return base.Set<TEntity>();
        }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }




        public DbEntityEntry Entry(Entities.BaseEntity entity)
        {
            return base.Entry(entity);
        }
    }
}
