using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.Repository.GenericRepository;

namespace MWIE.Repository.DetailReceiptExportRepository
{
    public class DetailReceiptExportRepository : GenericRepository<DetailReceiptExport>, IDetailReceiptExportRepository
    {
        public DetailReceiptExportRepository(MWIEDbContext context) : base(context)
        {
            
        }
    }
}