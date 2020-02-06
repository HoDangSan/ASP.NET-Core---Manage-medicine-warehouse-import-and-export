using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.Repository.GenericRepository;

namespace MWIE.Repository.ReceiptExportRepository
{
    public class ReceiptExportRepository : GenericRepository<ReceiptExport>, IReceiptExportRepository
    {
        public ReceiptExportRepository(MWIEDbContext context) : base(context)
        {
            
        }
    }
}