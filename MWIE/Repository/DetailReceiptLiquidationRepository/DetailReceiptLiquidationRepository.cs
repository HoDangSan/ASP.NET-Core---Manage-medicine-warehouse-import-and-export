using MWIE.Models;
using MWIE.Repository.GenericRepository;

namespace MWIE.Repository.DetailReceiptLiquidationRepository
{
    public class DetailReceiptLiquidationRepository : GenericRepository<DetailReceiptLiquidationRepository>, IDetailReceiptLiquidationRepository
    {
        public DetailReceiptLiquidationRepository(MWIEDbContext context) : base(context)
        {
            
        }
    }
}