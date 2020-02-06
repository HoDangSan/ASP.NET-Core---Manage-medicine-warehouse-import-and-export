using System.Collections.Generic;
using MWIE.Models.Entity;

namespace MWIE.Repository.GenericRepository
{
    public interface IGenericRepository<TEntity>
    {
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        void Save();

    }
}