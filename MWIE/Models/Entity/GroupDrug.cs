using System.Collections.Generic;
using System.ComponentModel;

namespace MWIE.Models.Entity
{
    public class GroupDrug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [DefaultValue("true")]
        public bool IsActive { get; set; }

        public virtual IEnumerable<Drug> Drugs { get; set; }
    }
}