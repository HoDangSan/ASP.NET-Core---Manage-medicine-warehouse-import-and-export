using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MWIE.Models.Entity
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        [DefaultValue("true")]
        public bool IsActive { get; set; }

        public IEnumerable<ReceiptExport> ReceiptExports { get; set; }
    }
}
