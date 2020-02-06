using System.Collections.Generic;
using MWIE.Models.Entity;

namespace MWIE.Service.DrugService
{
    public interface IDrugService
    {
        Drug GetById(int id);
        IEnumerable<Drug> GetAll();
        void Add(Drug drug);
        void Delete(int id);
        void Update(Drug drug);
        void Save();
    }
}