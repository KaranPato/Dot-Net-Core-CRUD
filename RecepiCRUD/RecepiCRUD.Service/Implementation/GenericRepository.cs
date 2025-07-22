using Microsoft.EntityFrameworkCore;
using RecepiCRUD.Entity;
using RecepiCRUD.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace RecepiCRUD.Service.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RecepiContext _recepiContext;
        private DbSet<T> _dbSet;

        public GenericRepository(RecepiContext recepiContext)
        {
            _recepiContext = recepiContext;
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
