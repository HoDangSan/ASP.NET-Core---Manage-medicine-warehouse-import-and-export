using System.Collections.Generic;
using MWIE.Models.Entity;

namespace MWIE.Service.ProducerService
{
    public interface IProducerService
    {
        Producer GetById(int id);
        IEnumerable<Producer> GetAll();
        void Add(Producer producer);
        void Delete(int id);
        void Update(Producer producer);
        void Save();
    }
}