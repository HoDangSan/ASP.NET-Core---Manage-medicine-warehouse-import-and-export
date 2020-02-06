using System.Collections.Generic;
using MWIE.Models.Entity;

namespace MWIE.Service.DetailReceiptImportService
{
    public interface IDetailReceiptImportService
    {
        DetailReceiptImport GetById(int id);
        IEnumerable<DetailReceiptImport> GetAll();
        void Add(DetailReceiptImport detailReceiptImport);
        void Delete(int id);
        void Update(DetailReceiptImport detailReceiptImport);
        void Save();
    }
}