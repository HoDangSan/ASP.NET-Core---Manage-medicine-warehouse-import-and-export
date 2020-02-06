using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.Repository.GenericRepository;

namespace MWIE.Repository.ReceiptLiquidationRepository
{
    public class ReceiptLiquidationRepository : GenericRepository<ReceiptLiquidation>, IReceiptLiquidationRepository
    {
        public ReceiptLiquidationRepository(MWIEDbContext context) : base(context)
        {
            
        }
    }
}