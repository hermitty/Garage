using System;

namespace Garage.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        void Save();
    }
}
