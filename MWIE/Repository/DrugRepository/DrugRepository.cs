using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.Repository.GenericRepository;

namespace MWIE.Repository.DrugRepository
{
    public class DrugRepository : GenericRepository<Drug>, IDrugRepository
    {
        public DrugRepository(MWIEDbContext context) : base(context)
        {
            
        }
    }
}