using MWIE.Models;
using MWIE.Repository.GenericRepository;

namespace MWIE.Repository.DetailReceiptImportRepository
{
    public class DetailReceiptImportRepository : GenericRepository<DetailReceiptImportRepository>, IDetailReceiptImportRepository
    {
        public DetailReceiptImportRepository(MWIEDbContext context) : base(context)
        {
            
        }
    }
}