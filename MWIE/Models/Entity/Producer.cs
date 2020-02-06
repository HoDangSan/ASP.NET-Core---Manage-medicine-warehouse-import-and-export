using System.Collections.Generic;
using System.ComponentModel;

namespace MWIE.Models.Entity
{
    public class Producer
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