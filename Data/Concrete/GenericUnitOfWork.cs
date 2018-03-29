using Data.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Concrete
{
    public class GenericUnitOfWork : IUnitOfWork ,IDisposable
    {
        private readonly ApplicationContext _context = null;
        private bool disposed = false;

        public GenericUnitOfWork()
        {
            _context = new ApplicationContext();
        }

        public Dictionary<Type, Object> repositories = new Dictionary<Type, object>();

        public IRepository<T> Repositories<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repo = new GenericRepository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
