using System.Collections.Generic;
using MWIE.Models.Entity;

namespace MWIE.Service.DetailReceiptLiquidationService
{
    public interface IDetailReceiptLiquidationService
    {
        DetailReceiptLiquidation GetById(int id);
        IEnumerable<DetailReceiptLiquidation> GetAll();
        void Add(DetailReceiptLiquidation detailReceiptLiquidation);
        void Delete(int id);
        void Update(DetailReceiptLiquidation detailReceiptLiquidation);
        void Save();
    }
}