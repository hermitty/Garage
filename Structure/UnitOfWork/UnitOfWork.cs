using Microsoft.EntityFrameworkCore;
using Structure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }
            IGenericRepository<T> repo = new GenericRepository<T>(context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
