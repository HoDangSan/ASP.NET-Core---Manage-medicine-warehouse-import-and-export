using System.Collections.Generic;
using System.ComponentModel;
using MWIE.Models.Entity;

namespace MWIE.Models.ViewModel
{
    public class ProducerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
        [DefaultValue("true")]
        public string IsActive { get; set; }

        public virtual IEnumerable<Drug> Drugs { get; set; }
    }
    
    public class ProducerViewModelEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
        [DefaultValue("true")]
        public bool IsActive { get; set; }

        public virtual IEnumerable<Drug> Drugs { get; set; }
    }
}