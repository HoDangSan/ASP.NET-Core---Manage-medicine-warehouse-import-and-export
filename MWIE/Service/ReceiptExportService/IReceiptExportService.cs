using System.Collections.Generic;
using MWIE.Models.Entity;

namespace MWIE.Service.ReceiptExportService
{
    public interface IReceiptExportService
    {
        ReceiptExport GetById(int id);
        IEnumerable<ReceiptExport> GetAll();
        void Add(ReceiptExport receiptExport);
        void Delete(int id);
        void Update(ReceiptExport receiptExport);
        void Save();
    }
}