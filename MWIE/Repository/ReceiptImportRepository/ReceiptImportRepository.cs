using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.Repository.GenericRepository;

namespace MWIE.Repository.ReceiptImportRepository
{
    public class ReceiptImportRepository : GenericRepository<ReceiptImport>, IReceiptImportRepository
    {
        public ReceiptImportRepository(MWIEDbContext context) : base(context)
        {
            
        }
    }
}