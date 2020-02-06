using System;
using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.Repository.GenericRepository;

namespace MWIE.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private MWIEDbContext _context;

        public UnitOfWork(MWIEDbContext context)
        {
            _context = context;
            InitReponsitory();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<UserProfile> UserReponsitory { get; private set; }
        public IGenericRepository<Producer> ProducerRepository { get; private set; }
        public IGenericRepository<GroupDrug> GroupDrugRepository { get; private set; }
        public IGenericRepository<Drug> DrugRepository { get; private set; }
        public IGenericRepository<DetailReceiptExport> DetailReceiptExportRepository { get; private set; }
        public IGenericRepository<ReceiptExport> ReceiptExportRepository { get; private set; }
        public IGenericRepository<ReceiptImport> ReceiptImportRepository { get; private set; }
        public IGenericRepository<DetailReceiptImport> DetailReceiptImportRepository { get; private set; }
        public IGenericRepository<ReceiptLiquidation> ReceiptLiquidationRepository { get; private set; }
        public IGenericRepository<DetailReceiptLiquidation> DetailReceiptLiquidationRepository { get; private set; }
        

        private void InitReponsitory()
        {
            UserReponsitory = new GenericRepository<UserProfile>(_context);
            ProducerRepository = new GenericRepository<Producer>(_context);
            GroupDrugRepository = new GenericRepository<GroupDrug>(_context);
            DrugRepository = new GenericRepository<Drug>(_context);
            DetailReceiptExportRepository = new GenericRepository<DetailReceiptExport>(_context);
            ReceiptExportRepository = new GenericRepository<ReceiptExport>(_context);
            ReceiptImportRepository = new GenericRepository<ReceiptImport>(_context);
            DetailReceiptImportRepository = new GenericRepository<DetailReceiptImport>(_context);
            ReceiptLiquidationRepository = new GenericRepository<ReceiptLiquidation>(_context);
            DetailReceiptLiquidationRepository = new GenericRepository<DetailReceiptLiquidation>(_context);
            
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}