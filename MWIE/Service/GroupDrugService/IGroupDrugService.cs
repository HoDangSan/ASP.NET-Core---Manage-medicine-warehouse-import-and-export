using System.Collections.Generic;
using MWIE.Models.Entity;

namespace MWIE.Service.GroupDrugService
{
    public interface IGroupDrugService
    {
        GroupDrug GetById(int id);
        IEnumerable<GroupDrug> GetAll();
        void Add(GroupDrug groupDrug);
        void Delete(int id);
        void Update(GroupDrug groupDrug);
        void Save();
    }
}