using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.Repository.GenericRepository;

namespace MWIE.Repository.GroupDrugRepository
{
    public class GroupDrugRepository : GenericRepository<GroupDrug>, IGroupDrugRepository
    {
        public GroupDrugRepository(MWIEDbContext context) : base(context)
        {
            
        }
    }
}