using Data.Abstracts;
using Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Service.Concrete
{
    public class GenericService<T> : IService<T> where T: class
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<T> _repo;

        public GenericService()
        {
            _uow = new GenericUnitOfWork();
            _repo = _uow.Repositories<T>();
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
           return _repo.GetAll(predicate);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _repo.Find(predicate);
        }

        public void Add(T entity)
        {
            _repo.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            _uow.Repositories<T>().Update(entity);
            Save();

        }

        public void Delete(T entity)
        {
            _repo.Delete(entity);
            Save();

        }

        protected void Save()
        {
            _uow.SaveChanges();
        }
    }
}
