﻿using Garage.Domain.Interface;
using Garage.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context context;
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork(Context context)
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
