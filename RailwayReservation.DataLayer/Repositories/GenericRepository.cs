using RailwayReservation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.DataLayer.Repositories
{
    public abstract class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        public GenericRepository(DbContext context)
        {
            this.Context = context;
        }

        private DbContext entities;

        public DbContext Context
        {
            get { return entities;}
            set { entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            entities.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity)
        {
            entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            entities.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
