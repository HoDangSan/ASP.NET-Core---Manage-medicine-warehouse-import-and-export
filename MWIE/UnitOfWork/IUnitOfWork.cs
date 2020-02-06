using System;
using MWIE.Models.Entity;
using MWIE.Repository.GenericRepository;

namespace MWIE.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<UserProfile> UserReponsitory { get; }
        IGenericRepository<Producer> ProducerRepository { get; }
        IGenericRepository<GroupDrug> GroupDrugRepository { get; }
        IGenericRepository<Drug> DrugRepository { get; }
        IGenericRepository<DetailReceiptExport> DetailReceiptExportRepository { get; }
        IGenericRepository<ReceiptExport> ReceiptExportRepository { get; }
        IGenericRepository<ReceiptImport> ReceiptImportRepository { get; }
        IGenericRepository<DetailReceiptImport> DetailReceiptImportRepository { get; }
        IGenericRepository<ReceiptLiquidation> ReceiptLiquidationRepository { get; }
        IGenericRepository<DetailReceiptLiquidation> DetailReceiptLiquidationRepository { get; }
        void Save();
    }

}