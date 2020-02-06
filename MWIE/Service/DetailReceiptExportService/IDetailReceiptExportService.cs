using System.Collections.Generic;
using MWIE.Models.Entity;

namespace MWIE.Service.DetailReceiptExportService
{
    public interface IDetailReceiptExportService
    {
        DetailReceiptExport GetById(int id);
        IEnumerable<DetailReceiptExport> GetAll();
        void Add(DetailReceiptExport detailReceiptExport);
        void Delete(int id);
        void Update(DetailReceiptExport detailReceiptExport);
        void Save();
    }
}