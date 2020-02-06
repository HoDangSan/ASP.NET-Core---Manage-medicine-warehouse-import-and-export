using System.Collections.Generic;
using MWIE.Models.Entity;

namespace MWIE.Service.ReceiptLiquidationService
{
    public interface IReceiptLiquidationService
    {
        ReceiptLiquidation GetById(int id);
        IEnumerable<ReceiptLiquidation> GetAll();
        void Add(ReceiptLiquidation receiptLiquidation);
        void Delete(int id);
        void Update(ReceiptLiquidation receiptLiquidation);
        void Save();
    }
}