using System.Collections.Generic;
using System.ComponentModel;
using MWIE.Models.Entity;

namespace MWIE.Models.ViewModel
{
    public class GroupDrugViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [DefaultValue("true")]
        public string IsActive { get; set; }

        public virtual IEnumerable<Drug> Drugs { get; set; }
    }
    
    public class GroupDrugViewModelEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [DefaultValue("true")]
        public bool IsActive { get; set; }

        public virtual IEnumerable<Drug> Drugs { get; set; }
    }
}