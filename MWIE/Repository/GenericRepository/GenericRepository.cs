using System;
using System.Collections.Generic;
using MWIE.Models;
using MWIE.Models.Entity;

namespace MWIE.Repository.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly MWIEDbContext _context;

        public GenericRepository(MWIEDbContext context)
        {
            _context = context;
        }

        public TEntity GetById(int? id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(int id)
        {
            try
            {
                TEntity tentity = _context.Set<TEntity>().Find(id);
                _context.Set<TEntity>().Remove(tentity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}