using System.Collections.Generic;
using MWIE.Models.Entity;

namespace MWIE.Service.ReceiptImportService
{
    public interface IReceiptImportService
    {
        ReceiptImport GetById(int id);
        IEnumerable<ReceiptImport> GetAll();
        void Add(ReceiptImport receiptImport);
        void Delete(int id);
        void Update(ReceiptImport receiptImport);
        void Save();
    }
}